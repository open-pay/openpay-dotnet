using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class CustomerService : OpenpayResourceService<Customer, Customer>
    {

        public CustomerService(string api_key, string merchant_id, Countries country, bool production = false)
            : base(api_key, merchant_id, country, production)
        {
            ResourceName = "customers";
        }

        internal CustomerService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "customers";
        }

        public Customer Create(Customer customer)
        {
            return base.Create(null, customer);
        }

        public Customer Update(Customer customer)
        {
            return base.Update(null, customer);
        }

        public void Delete(string customer_id)
        {
            base.Delete(null, customer_id);
        }

        public Customer Get(string customer_id)
        {
            return base.Get(null, customer_id);
        }

        public List<Customer> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }
    }
}
