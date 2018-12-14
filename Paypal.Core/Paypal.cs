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
        #region 常量
        private const string _domain = "https://api.paypal.com";
        private const string _sandboxDomain = "https://api.sandbox.paypal.com";
        #endregion

        #region 参数
        private string _clientId;
        private string _secret;

        /// <summary>
        /// 商户账号邮箱
        /// </summary>
        private string _email;

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsLive { get; set; }

        /// <summary>
        /// 当前域名
        /// </summary>
        private string _currentDomain
        {
            get
            {
                if (IsLive)
                {
                    return _domain;
                }
                else
                {
                    return _sandboxDomain;
                }

            }
        }

        /// <summary>
        /// 当前token Live Sandbox
        /// </summary>
        private string _currentTokenType
        {
            get
            {
                if (IsLive)
                {
                    return "Live";
                }
                else
                {
                    return "Sandbox";
                }
            }
        }

        /// <summary>
        /// 请求客户端
        /// </summary>
        HttpClientHelp client;
        #endregion

        #region 00 初始化参数
        /// <summary>
        /// 初始化参数
        /// </summary>
        public void Init()
        {
            client = new HttpClientHelp();
            _clientId = UntityTool.GetConfigValue("ClientId_" + _currentTokenType);
            _secret = UntityTool.GetConfigValue("Secret_" + _currentTokenType);
            _email = UntityTool.GetConfigValue("Email_" + _currentTokenType);
        }
        #endregion

        #region 01 获取token - bool GetToken(out PaypalToken token)
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool GetToken(out PaypalToken token)
        {
            token = null;
            bool needRequest = false;
            try
            {
                token = PaypalTokenService.Select(string.Format(" where TokenType='{0}'", _currentTokenType)).FirstOrDefault();
                if (token != null)
                {
                    if (token.ExpriseTime <= DateTime.Now)
                    {
                        PaypalToken pInfo = PaypalTokenService.Select(string.Format(" where TokenType='{0}'", _currentTokenType)).FirstOrDefault();
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
                    string content = client.Post(_currentDomain + "/v1/oauth2/token", "grant_type=client_credentials");
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
                            //TokenType
                            token.TokenType = _currentTokenType;

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
        #endregion

        #region 02 创建账单 + bool CreateInvoice()
        /// <summary>
        /// 创建账单
        /// </summary>
        /// <param name="username">账单收件人名称</param>
        /// <param name="useremail">账单收件人邮箱</param>
        /// <param name="itemname">项目名称</param>
        /// <param name="qty">项目数量</param>
        /// <param name="price">单价(RMB)</param>
        /// <param name="remark">备注</param>
        /// <param name="invoices">创建的账单草稿信息</param>
        /// <returns></returns>
        public bool CreateInvoice(string username, string useremail, string itemname, int qty, decimal price, string remark, out ResultInvoices invoices)
        {
            string access_token = string.Empty;
            invoices = null;
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
                string param = GenerateJsonParams(username, useremail, itemname, qty, price, remark);

                string content = client.Post(_currentDomain + "/v1/invoicing/invoices", param, "application/json");
                if (!string.IsNullOrEmpty(content))
                {
                    invoices = new ResultInvoices();

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
        #endregion

        #region 03 组装账单Body参数 json格式 - string GenerateJsonParams()
        private string GenerateJsonParams(string username, string useremail, string itemname, int qty, decimal price, string remark)
        {
            InvoiceBody body = new InvoiceBody();
            body.note = string.Format("{0};【注意】务必使用账单中的邮件注册的Paypal账户付款！", remark);
            body.terms = "30天内付款有效";
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
                      name=itemname,
                      quantity=qty,
                      tax=new tax(){ name="Tax", percent=0 },
                      unit_price=new unit_price(){ currency="USD",value=Math.Round(price/6.7m,2) }
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
                first_name = "519社区",
                last_name = "会员"
            };
            body.billing_info = new List<billing_info>()
            {
                 new billing_info()
                 {
                     email =useremail,
                     first_name =username,
                     last_name ="VIP开通"
                 }
            };
            body.merchant_info = new merchant_info()
            {
                business_name = "591av.online",
                phone = new phone() { country_code = "001", national_number = "123456" },
                email = _email,
                first_name = "VIP开通",
                last_name = "&591社区",
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
        #endregion

        #region 04 发送账单 + bool SendInvoice(ResultInvoices invoices)

        public bool SendInvoice(ResultInvoices invoices)
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

                Urls send = invoices.GetUrls(RelType.发送);
                string content = client.Post(send.href, "");
                if (!string.IsNullOrEmpty(content) && content == "202")
                {
                    //成功
                    LogHelp.Info("发送账单成功!");
                    return true;
                }
                else
                {
                    //失败
                    LogHelp.Error("发送账单错误!");
                    return false;
                }
            }
            return false;
        }

        #endregion
    }
}
