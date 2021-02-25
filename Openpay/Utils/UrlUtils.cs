using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Openpay.Utils
{
    public class UrlUtils
    {
        public string ScapeSquareBrackets(string url)
                {
                    url = url.Replace("[", System.Net.WebUtility.UrlEncode("["));
                    url = url.Replace("]", System.Net.WebUtility.UrlEncode("]"));
                    return url;
                }
    }
}
