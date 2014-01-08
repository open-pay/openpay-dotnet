using Openpay.Entities;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class CustomerService 
    {

        static readonly string base_path = "/customers";

        static readonly string customer_path = base_path + "/{0}";

        private OpenpayHttpClient httpClient;

        public CustomerService(string api_key, string merchant_id, bool production = false)
        {
            this.httpClient = new OpenpayHttpClient(api_key, merchant_id, production);
        }

        internal CustomerService(OpenpayHttpClient opHttpClient)
        {
            this.httpClient = opHttpClient;
        }

        public Customer Create(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            return this.httpClient.Post<Customer>(base_path, customer);
        }

        public void Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");
            string ep = String.Format(customer_path, id);
            this.httpClient.Delete(ep);
        }

        public Customer Update(string id, Customer customer)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");
            if (customer == null)
                throw new ArgumentNullException("customer");

            string ep = String.Format(customer_path, id);
            return this.httpClient.Put<Customer>(ep, customer);
        }

        public Customer Get(string customer_id)
        {
            if (String.IsNullOrEmpty(customer_id))
                throw new ArgumentNullException("customer_id");

            string path = String.Format(customer_path, customer_id);
            return this.httpClient.Get<Customer>(path);
        }

        public virtual List<Customer> List(int limit = 10, int offset = 0)
        {
            string url = base_path;
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (limit < 1 || limit > 100)
                throw new ArgumentOutOfRangeException("limit");

            url = ParameterBuilder.ApplyParameterToUrl(url, "limit", limit.ToString());
            url = ParameterBuilder.ApplyParameterToUrl(url, "offset", offset.ToString());

            return this.httpClient.Get<List<Customer>>(url);
        }
    }
}
