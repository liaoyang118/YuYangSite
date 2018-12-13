using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Paypal.Core.Model;
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
                        PaypalToken pInfo = PaypalTokenService.Select("").FirstOrDefault();
                        if (pInfo != null)
                        {
                            PaypalTokenService.Delete(pInfo.Id);
                        }
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

                            PaypalTokenService.Insert(token);

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


        public bool CreateInvoice()
        {
            string access_token = string.Empty;
            PaypalToken currentToken;
            bool isSuccess = GetToken(out currentToken);
            if (isSuccess)
            {
                access_token = currentToken.Token;
            }

            if (!string.IsNullOrEmpty(access_token))
            {
                client.Accept = "application/json";
                client.ContentType = "application/json";
                client.AddHeaders("Authorization", string.Format("Bearer {0}", access_token));

                //构建body参数 json格式
                string param = GenerateJsonParams();

                string content = client.Post(CurrentDomain + "/v1/invoicing/invoices", param, "application/json");
                if (!string.IsNullOrEmpty(content))
                {
                    ResultInvoices invoices = new ResultInvoices();

                    string result = string.Empty;
                    JObject obj = (JObject)JsonConvert.DeserializeObject(content);

                    JToken token;
                    obj.TryGetValue("number", out token);
                    if (token != null)
                    {
                        invoices.number = token.ToString();
                        //id
                        obj.TryGetValue("id", out token);
                        invoices.id = token.ToString();
                        //template_id
                        obj.TryGetValue("template_id", out token);
                        invoices.template_id = token.ToString();
                        //status
                        obj.TryGetValue("status", out token);
                        invoices.status = token.ToString();

                        //links
                        obj.TryGetValue("links", out token);
                        List<Urls> list = JsonConvert.DeserializeObject<List<Urls>>(token.ToString());
                        invoices.links = list;

                        return true;
                    }
                    else
                    {
                        //失败
                        LogHelp.Error("创建账单错误!");
                        return false;
                    }
                }
            }
            return false;
        }

        private string GenerateJsonParams()
        {
            InvoiceBody body = new InvoiceBody();
            body.note = "请注册账号后付款";
            body.terms = "请在30天内付款";
            //body.discount = new discount() { percent = 0.00 };
            body.shipping_cost = new shipping_cost()
            {
                amount = new amount()
                {
                    currency = "USD",
                    value = 0
                }
            };
            body.items = new List<item>() {
                 new item()
                 {
                      name="商品1",
                      quantity=1,
                      tax=new tax(){ name="Tax", percent=0 },
                      unit_price=new unit_price(){ currency="USD",value=1.5m }
                 }
            };
            body.shipping_info = new shipping_info()
            {
                //address = new address()
                //{
                //    city = "",
                //    country_code = "",
                //    line1 = "",
                //    postal_code = "",
                //    state = ""
                //},
                first_name = "VIP",
                last_name = "开通"
            };
            body.billing_info = new List<billing_info>()
            {
                 new billing_info()
                 {
                     email ="vipactive@outlook.com",
                     first_name ="VIP",
                     last_name ="开通"
                 }
            };
            body.merchant_info = new merchant_info()
            {
                business_name = "591av",
                phone = new phone() { country_code = "001", national_number = "123456" },
                email = "liao.yang118-facilitator@163.com",
                first_name = "591av",
                last_name = "community",
                //address = new address()
                //{
                //    city = "",
                //    country_code = "",
                //    line1 = "",
                //    postal_code = "",
                //    state = ""
                //}
            };

            string result = UntityTool.GetJsonByObject(body);

            return result;
        }

    }
}
