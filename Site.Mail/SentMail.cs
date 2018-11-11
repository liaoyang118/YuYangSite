using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SentMail
{
    public class SentMail
    {
        SmtpClient smtp;
        MailMessage mm;
        public string error;

        Config _config;
        public SentMail()
        {
            _config = new Config();
        }

        public void SentNetMail(out string error)
        {
            error = string.Empty;
            if (smtp != null)
            {
                try
                {
                    smtp.Send(mm);
                }
                catch (Exception e)
                {
                    error = e.Message + (e.InnerException == null ? "" : e.InnerException.Message);
                }
            }
        }

        public void Init(string name, string title, string to, string content, bool enableSSL = false)
        {
            smtp = new SmtpClient(); //实例化一个SmtpClient
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
            smtp.EnableSsl = enableSSL;//smtp服务器是否启用SSL加密
            smtp.Host = _config.Smtp; //指定 smtp 服务器地址
            smtp.Port = _config.Port; //指定 smtp 服务器的端口，默认是25，如果采用默认端口，可省去
            smtp.UseDefaultCredentials = false;
            //认证
            smtp.Credentials = new NetworkCredential(_config.Account, _config.Pwd);
            mm = new MailMessage(); //实例化一个邮件类
            mm.Priority = MailPriority.Normal; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
            mm.From = new MailAddress(_config.Account, name, Encoding.GetEncoding(936));
            mm.Sender = new MailAddress(_config.Account, name, Encoding.GetEncoding(936));
            mm.To.Add(to);
            mm.Subject = title; //邮件标题
            mm.SubjectEncoding = Encoding.GetEncoding(936);
            // 这里非常重要，如果你的邮件标题包含中文，这里一定要指定，否则对方收到的极有可能是乱码。
            // 936是简体中文的pagecode，如果是英文标题，这句可以忽略不用
            mm.IsBodyHtml = true; //邮件正文是否是HTML格式
            mm.BodyEncoding = Encoding.GetEncoding(936);
            //邮件正文的编码， 设置不正确， 接收者会收到乱码
            mm.Body = content;

            //添加附件，第二个参数，表示附件的文件类型，可以不用指定
            //mm.Attachments.Add(new Attachment(@"C:\Users\Administrator\Desktop\lln.docx", System.Net.Mime.MediaTypeNames.Application.Rtf));

        }
    }
}
