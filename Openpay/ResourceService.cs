using Openpay.Entities;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public abstract class ResourceService<T, R> where T : OpenpayObject
    {
        protected OpenpayHttpClient httpClient;

        public ResourceService(string api_key, string merchant_id, bool production = false)
        {
            this.httpClient = new OpenpayHttpClient(api_key, merchant_id, production);
        }

        internal ResourceService(OpenpayHttpClient opHttpClient)
        {
            this.httpClient = opHttpClient;
        }

        public abstract String GetMerchantPath();

        public abstract String GetCustomerPath();

        protected String GetEndPoint(string customer_id, string obj_id = null)
        {
            string ep = GetMerchantPath();
            if (customer_id != null)
            {
                ep = String.Format(GetCustomerPath(), customer_id);
            }
            if (obj_id != null)
            {
                ep = ep + "/" + obj_id;
            }
            return ep;
        }

        public virtual R Create(T obj, string customer_id = null)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to create is null");
            string ep = GetEndPoint(customer_id);
            return this.httpClient.Post<R>(ep, obj);
        }

        public virtual void Delete(string obj_id, string customer_id = null)
        {
            if (String.IsNullOrEmpty(obj_id))
                throw new ArgumentNullException("The id of the object cannot be null");
            string ep = GetEndPoint(customer_id, obj_id);
            this.httpClient.Delete(ep);
        }

        public virtual R Get(string obj_id, string customer_id = null)
        {
            string ep = GetEndPoint(customer_id, obj_id);
            return this.httpClient.Get<R>(ep);
        }

        public virtual List<R> List(string customer_id = null, int limit = 10, int offset = 0)
        {
            string url = GetEndPoint(customer_id);
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit < 1 || limit > 100)
                throw new ArgumentOutOfRangeException("limit");

            url = ParameterBuilder.ApplyParameterToUrl(url, "limit", limit.ToString());
            url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

            return this.httpClient.Get<List<R>>(url);
        }
    }
}
