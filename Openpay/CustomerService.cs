using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public class CustomerService : OpenpayResourceService<Customer, Customer>, ICustomerService
    {

        public CustomerService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
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
