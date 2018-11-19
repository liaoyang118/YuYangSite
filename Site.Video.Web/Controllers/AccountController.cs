using Site.Untity;
using Site.Video.Web.Tools;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using Site.Videos.DataAccess.Service.PartialService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site.Video.Web.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(string name, string pwd)
        {
            UserInfoSearchInfo search = new UserInfoSearchInfo
            {
                Account = name
            };
            IList<MySql_UserInfo> list = MySql_UserInfoService.Select(search.ToWhereString());
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    ModelState.AddModelError("500", "该账号存在多个相同账号，不能使用！");
                }
                else
                {
                    MySql_UserInfo uInfo = list.FirstOrDefault();
                    if ((int)SiteEnum.AccountState.正常 == uInfo.u_status)
                    {
                        string md5Str = UntityTool.Md5_32(pwd);
                        if (md5Str == uInfo.u_pwd)
                        {
                            //保存用户
                            HttpContextUntity.CurrentUser = uInfo;
                            string remenber = Request["remenber"] ?? string.Empty;

                            #region ticket 方法

                            //创建一个新的票据，将客户ip记入ticket的userdata 
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1, name, DateTime.Now, DateTime.Now.AddHours(2), false, uInfo.Id.ToString());
                            //将票据加密 
                            string authTicket = FormsAuthentication.Encrypt(ticket);
                            //将加密后的票据保存为cookie 
                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);
                            if (!string.IsNullOrEmpty(remenber))
                            {
                                cookie.Expires = DateTime.Now.AddDays(1);
                            }
                            //使用加入了userdata的新cookie 
                            Response.Cookies.Add(cookie);
                            //取值
                            //((System.Web.Security.FormsIdentity)this.Context.User.Identity).Ticket.UserData
                            #endregion

                            return RedirectToAction("index", "home");
                        }
                        else
                        {
                            ModelState.AddModelError("403", "密码错误，请确认！");
                        }
                    }
                    else
                    {
                        MySql_ActiveAccountInfo aInfo = new MySql_ActiveAccountInfo();
                        aInfo.Account = name;
                        aInfo.CreateTime = DateTime.Now;
                        aInfo.GUID = UntityTool.GetGUID();
                        aInfo.IsActive = false;
                        aInfo.TimeSpan = UntityTool.GetTimeSpan().ToString();
                        aInfo.Token = UntityTool.Md5_32(aInfo.Account + aInfo.TimeSpan);
                        aInfo.ActiveTime = DateTime.Now;

                        int result = MySql_ActiveAccountInfoService.Insert(aInfo);
                        if (result > 0)
                        {
                            bool isSuccess = SendActiveMail(aInfo);
                            return RedirectToAction("Notify", "Account", new { msg = HttpUtility.UrlEncode("该账户未激活，已经发送激活链接到注册账户的邮箱中，请打开邮箱，并激活账户！") });
                        }
                        ModelState.AddModelError("503", "账号异常，请稍后重新尝试！");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("404", "账号不存在，请确认！");
            }

            return View();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Regist()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Regist(string name, string pwd, string confirmPwd)
        {
            if (pwd != confirmPwd)
            {
                ModelState.AddModelError("401", "密码和确认密码不一致！");
            }
            else
            {
                UserInfoSearchInfo search = new UserInfoSearchInfo
                {
                    Account = name
                    //AccountState = (int)SiteEnum.AccountState.正常
                };

                IList<MySql_UserInfo> list = MySql_UserInfoService.Select(search.ToWhereString());
                if (list.Count > 0)
                {
                    ModelState.AddModelError("404", "该注册账户已存在，请更换注册账号后重新尝试！");
                }
                else
                {
                    MySql_UserInfo uInfo = new MySql_UserInfo();
                    uInfo.u_expriseTime = null;
                    uInfo.u_level = (int)SiteEnum.AccountLevel.普通用户;
                    uInfo.u_name = name;
                    uInfo.u_pwd = UntityTool.Md5_32(pwd);
                    uInfo.u_regTime = DateTime.Now;
                    uInfo.u_status = (int)SiteEnum.AccountState.无效;
                    uInfo.u_gid = UntityTool.GetGUID();
                    uInfo.u_expriseTime = DateTime.Now;

                    int result = MySql_UserInfoService.Insert(uInfo);
                    if (result > 0)
                    {
                        #region 自动登录
                        ////保存用户
                        //HttpContextUntity.CurrentUser = uInfo;

                        //#region ticket 方法

                        ////创建一个新的票据，将客户ip记入ticket的userdata 
                        //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        //1, name, DateTime.Now, DateTime.Now.AddHours(2), false, uInfo.Id.ToString());
                        ////将票据加密 
                        //string authTicket = FormsAuthentication.Encrypt(ticket);
                        ////将加密后的票据保存为cookie 
                        //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);

                        ////使用加入了userdata的新cookie 
                        //Response.Cookies.Add(cookie);
                        //#endregion

                        //return RedirectToAction("index", "home"); 
                        #endregion

                        MySql_ActiveAccountInfo aInfo = new MySql_ActiveAccountInfo();
                        aInfo.Account = name;
                        aInfo.CreateTime = DateTime.Now;
                        aInfo.GUID = UntityTool.GetGUID();
                        aInfo.IsActive = false;
                        aInfo.TimeSpan = UntityTool.GetTimeSpan().ToString();
                        aInfo.Token = UntityTool.Md5_32(aInfo.Account + aInfo.TimeSpan);
                        aInfo.ActiveTime = DateTime.Now;

                        result = MySql_ActiveAccountInfoService.Insert(aInfo);
                        if (result > 0)
                        {
                            bool isSuccess = SendActiveMail(aInfo);

                            return RedirectToAction("Notify", "Account", new { msg = HttpUtility.UrlEncode("注册成功，稍等5分钟将会发送一封激活邮件到您的注册邮箱，请登录邮箱激活账户！") });
                        }
                        else
                        {
                            ModelState.AddModelError("500", "注册失败，请稍后再试！");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("500", "注册失败，请稍后再试！");
                    }
                }
            }

            return View();
        }


        public void LoginOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        [AllowAnonymous]
        public ActionResult Notify(string msg)
        {
            ViewBag.Message = HttpUtility.UrlDecode(msg);
            return View();
        }

        [AllowAnonymous]
        public ActionResult ActiveMail(string gid, string at, string ts)
        {
            ActiveAccountInfo aInfo = ActiveAccountInfoService.Select(string.Format(" where GUID='{0}'", gid)).FirstOrDefault();
            string message = string.Empty;
            if (aInfo != null)
            {
                if (!aInfo.IsActive)
                {
                    if (aInfo.Token == UntityTool.Md5_32(at + ts))
                    {

                        aInfo.IsActive = true;
                        aInfo.ActiveTime = DateTime.Now;
                        ActiveAccountInfoService.Update(aInfo);

                        UserInfo uInfo = UserInfoService.Select(string.Format(" where u_name = '{0}'", aInfo.Account)).FirstOrDefault();
                        uInfo.u_status = (int)SiteEnum.AccountState.正常;
                        UserInfoService.Update(uInfo);

                        message = "激活成功，<a href=\"/Account/Login\">立即登录</a>！";
                    }
                    else
                    {
                        message = "激活失败，没有该账户的注册信息！";
                    }
                }
                else
                {
                    message = "该账户已经激活，无需重复激活！";
                }
            }
            else
            {
                message = "激活失败，没有该账户的注册信息！";
            }

            return RedirectToAction("Notify", "Account", new { msg = HttpUtility.UrlEncode(message) });
        }


        private bool SendActiveMail(MySql_ActiveAccountInfo aInfo)
        {
            string url = string.Format("http://{0}/Account/ActiveMail?gid={1}&at={2}&ts={3}", UntityTool.GetConfigValue("Domain"), aInfo.GUID, aInfo.Account, aInfo.TimeSpan);

            //内容
            StringBuilder sb = new StringBuilder();
            sb.Append("请点击以下链接，激活账户，如果点击无效，复制该链接到浏览器地址中访问。\r\n");
            sb.AppendFormat("<a href=\"{0}\" target=\"_blank\">{0}</a>", url);
            string content = sb.ToString();

            //发送邮件
            SentMail.SentMail sm = new SentMail.SentMail();
            sm.Init(UntityTool.GetConfigValue("mailAccount"), "账号激活", aInfo.Account, content, true);
            string error;
            sm.SentNetMail(out error);

            //记录日志
            bool isSendSuccess = string.IsNullOrEmpty(error) ? true : false;
            MySql_SendMailLog smInfo = new MySql_SendMailLog();
            smInfo.CreateTime = DateTime.Now;
            smInfo.Email = aInfo.Account;
            smInfo.IsSuccess = isSendSuccess;
            smInfo.Remark = error;
            smInfo.SendContent = content;
            smInfo.SendTime = DateTime.Now;
            smInfo.Title = "账号激活";
            MySql_SendMailLogService.Insert(smInfo);


            return isSendSuccess;
        }

    }
}