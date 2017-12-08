using AppVersionControl.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winner.Framework.Encrypt;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.WebApi.Contract;

namespace AppVersionControl.Api.Models
{
    public class ApiVerification : DefaultApiVerification
    {
        public override bool VerifySignature(ActionParameter para)
        {
            AppInfo app = AppInfo.Get(para.MerchantNo);
            if (app == null)
            {
                return false;
            }
            string secret = app.Secret_Key;
            string encodeData = string.Concat(para.Data, secret);
            string hash = MD5Provider.Encode(encodeData);
            if (!hash.Equals(para.Sign, StringComparison.OrdinalIgnoreCase))
            {
                Log.Debug("签名数据：{0}", encodeData);
                Log.Debug("本地哈希：{0}", hash);
                Log.Debug("远程哈希：{0}", para.Sign);
                return false;
            }
            return true;
        }
    }
}