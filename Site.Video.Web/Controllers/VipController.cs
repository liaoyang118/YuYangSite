using Site.Untity;
using Site.Video.Web.Tools;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Video.Web.Controllers
{
    public class VipController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            //获取套餐内容
            List<ComboInfo> list = ComboInfoService.Select(string.Format(" where c_status={0} order by c_num", (int)SiteEnum.BasicStatus.有效)).ToList();


            ViewData["list"] = list;
            return View();
        }



        public ActionResult Dredge(string code)
        {
            ComboInfo cInfo = ComboInfoService.Select(string.Format(" where c_id='{0}'", code)).FirstOrDefault();

            string message = "开通失败，请稍后再试！";
            if (cInfo != null)
            {
                MySql_UserInfo uInfo = HttpContextUntity.CurrentUser;
                if (uInfo != null)
                {
                    //读取邮件模板
                    string filePath = Server.MapPath("../Html/MailTemplate.html");
                    string result = UntityTool.ReadFile(filePath);
                    string activeCode = "vip" + UntityTool.Md5_32(uInfo.u_name + UntityTool.GetTimeSpan().ToString()).Substring(0, 10);
                    string content = string.Format(result, cInfo.c_days, cInfo.c_num, uInfo.u_name, activeCode);


                    //发送邮件
                    SentMail.SentMail sm = new SentMail.SentMail();
                    sm.Init(UntityTool.GetConfigValue("mailAccount"), "开通会员", uInfo.u_name, content, true);
                    string error;
                    sm.SentNetMail(out error);

                    //记录Vip开通日志
                    ActiveVipInfo avInfo = new ActiveVipInfo();
                    avInfo.active_code = activeCode;
                    avInfo.create_time = DateTime.Now;
                    avInfo.c_days = cInfo.c_days.Value;
                    avInfo.c_num = cInfo.c_num.Value;
                    avInfo.IsPay = false;
                    avInfo.pay_time = DateTime.Now;
                    avInfo.u_name = uInfo.u_name;
                    avInfo.u_id = uInfo.Id;
                    ActiveVipInfoService.Insert(avInfo);

                    //记录邮件日志
                    bool isSendSuccess = string.IsNullOrEmpty(error) ? true : false;
                    SendMailLog smInfo = new SendMailLog();
                    smInfo.CreateTime = DateTime.Now;
                    smInfo.Email = uInfo.u_name;
                    smInfo.IsSuccess = isSendSuccess;
                    smInfo.Remark = error;
                    smInfo.SendContent = content;
                    smInfo.SendTime = DateTime.Now;
                    smInfo.Title = "开通会员";
                    SendMailLogService.Insert(smInfo);

                    if (isSendSuccess)
                    {
                        message = "申请成功，我们发送了邮件到注册账户的邮箱中，具体开通步骤请查看邮件！<br/>【收件箱中如没有，请查看垃圾箱】<br>图片如果未显示，点击邮件内容上方的显示图片<br>或是将邮箱添加为好友后再次申请开通Vip";
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                message = "开通失败，该套餐已经下架，请重新选择其它套餐！";
            }


            return RedirectToAction("Notify", "Account", new { msg = HttpUtility.UrlEncode(message) });
        }

    }
}