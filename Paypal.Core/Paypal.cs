using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Site.Log;
using Site.Untity;
using Site.Videos.DataAccess.Model;
using Site.Videos.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paypal.Core
{
    public class Paypal
    {
        private const string _domain = "https://api.paypal.com";
        private const string _sandboxDomain = "https://api.sandbox.paypal.com";
        private string _clientId;
        private string _secret;

        /// <summary>
        /// 是否沙盒
        /// </summary>
        public bool IsSandBox { get; set; }

        /// <summary>
        /// 当前域名
        /// </summary>
        private string CurrentDomain
        {
            get
            {
                if (IsSandBox)
                {
                    return _sandboxDomain;
                }
                else
                {
                    return _domain;
                }

            }
        }

        HttpClientHelp client;

        public Paypal()
        {
            client = new HttpClientHelp();
            _clientId = UntityTool.GetConfigValue("ClientId");
            _secret = UntityTool.GetConfigValue("Secret");
        }


        private bool GetToken(out PaypalToken token)
        {
            token = null;
            bool needRequest = false;
            try
            {
                token = PaypalTokenService.Select("").FirstOrDefault();
                if (token != null)
                {
                    if (token.ExpriseTime <= DateTime.Now)
                    {
                        //需要重新获取token
                        needRequest = true;
                    }
                }
                else
                {
                    //获取token
                    needRequest = true;
                }

                if (needRequest)
                {
                    token = new PaypalToken();

                    client.Accept = "application/json";
                    client.ContentType = "application/x-www-form-urlencoded";
                    client.SetAuthorizationHead(_clientId, _secret);
                    string content = client.Post(CurrentDomain + "/v1/oauth2/token", "grant_type=client_credentials");
                    if (!string.IsNullOrEmpty(content))
                    {
                        string access_token = string.Empty;
                        JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                        JToken jtoken;
                        obj.TryGetValue("access_token", out jtoken);
                        if (jtoken != null)
                        {
                            token.Token = jtoken.ToString();
                            //expires_in
                            obj.TryGetValue("expires_in", out jtoken);
                            token.ExpriseTime = DateTime.Now.AddSeconds(jtoken.ToString().ToInt32(0));
                            return true;
                        }
                        else
                        {
                            //失败
                            LogHelp.Error("获取access_token错误!");
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelp.Error("获取access_token错误:" + ex.Message);
                return false;
            }
        }

        public string GetCurrentToken()
        {
            PaypalToken obj;
            bool isSuccess = GetToken(out obj);
            if (isSuccess)
            {
                PaypalToken pInfo = PaypalTokenService.Select("").FirstOrDefault();
                if (pInfo != null)
                {
                    PaypalTokenService.Delete(pInfo.Id);
                }
                PaypalTokenService.Insert(obj);

                return obj.Token;
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
