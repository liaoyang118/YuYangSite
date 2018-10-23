using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentMail
{
    public class Config
    {
        string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        string smtp;

        public string Smtp
        {
            get { return smtp; }
            set { smtp = value; }
        }

        int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public Config()
        {
            account = System.Configuration.ConfigurationManager.AppSettings["mailAccount"];
            pwd = System.Configuration.ConfigurationManager.AppSettings["mailPwd"];
            smtp = System.Configuration.ConfigurationManager.AppSettings["smtp"];
            port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["port"]);
        }


    }
}
