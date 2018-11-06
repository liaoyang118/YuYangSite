using Site.Untity;
using Site.Video.Web.Tools;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using Site.Videos.DataAccess.Service.PartialService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Account = name,
                AccountState = (int)SiteEnum.AccountState.正常
            };

            IList<UserInfo> list = UserInfoService.Select(search.ToWhereString());
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    ModelState.AddModelError("500", "该账号存在多个同名账号，请联系客服处理！");
                }
                else
                {
                    UserInfo uInfo = list.FirstOrDefault();
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
                    Account = name,
                    AccountState = (int)SiteEnum.AccountState.正常
                };

                IList<UserInfo> list = UserInfoService.Select(search.ToWhereString());
                if (list.Count > 0)
                {
                    ModelState.AddModelError("404", "该注册账户已存在，请更换注册账号后重新尝试！");
                }
                else
                {
                    UserInfo uInfo = new UserInfo();
                    uInfo.u_expriseTime = null;
                    uInfo.u_level = (int)SiteEnum.AccountLevel.普通用户;
                    uInfo.u_name = name;
                    uInfo.u_pwd = UntityTool.Md5_32(pwd);
                    uInfo.u_regTime = DateTime.Now;
                    uInfo.u_status = (int)SiteEnum.AccountState.正常;
                    uInfo.u_gid = UntityTool.GetGUID();
                    int result = UserInfoService.Insert(uInfo);
                    if (result > 0)
                    {
                        //保存用户
                        HttpContextUntity.CurrentUser = uInfo;

                        #region ticket 方法

                        //创建一个新的票据，将客户ip记入ticket的userdata 
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1, name, DateTime.Now, DateTime.Now.AddHours(2), false, uInfo.Id.ToString());
                        //将票据加密 
                        string authTicket = FormsAuthentication.Encrypt(ticket);
                        //将加密后的票据保存为cookie 
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, authTicket);

                        //使用加入了userdata的新cookie 
                        Response.Cookies.Add(cookie);
                        #endregion

                        return RedirectToAction("index", "home");
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

    }
}