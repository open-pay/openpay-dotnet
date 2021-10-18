using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public abstract class OpenpayGenericService
    {
        protected OpenpayHttpClient httpClient;

        private static readonly string filter_date_format = "yyyy-MM-dd";

        private static readonly string filter_amount_format = "0.00";

		public OpenpayGenericService(string api_key, string merchant_id, Countries country, bool production = false)
        {
            this.httpClient = new OpenpayHttpClient(api_key, merchant_id, country, production);
        }

		internal OpenpayGenericService(OpenpayHttpClient opHttpClient)
        {
            this.httpClient = opHttpClient;
        }
			
        protected virtual T Get<T>(string ep)
        {
            return this.httpClient.Get<T>(ep);
        }

        protected List<T> List<T>(string url)
        {
            return this.httpClient.Get<List<T>>(url);
        }
    }
}
