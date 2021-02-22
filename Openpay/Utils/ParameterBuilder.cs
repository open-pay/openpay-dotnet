using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Openpay.Utils
{
    internal static class ParameterBuilder
    {
        public static string ApplyParameterToUrl(string url, string argument, string value)
        {
            UrlUtils urlUtils = new UrlUtils();
            var token = "&";

            if (!url.Contains("?"))
                token = "?";

            return urlUtils.ScapeSquareBrackets(string.Format("{0}{1}{2}={3}", url, token, argument, HttpUtility.UrlEncode(value)));
        }
    }
}
