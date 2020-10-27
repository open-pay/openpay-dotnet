using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        void Delete(string customer_id);
        Customer Get(string customer_id);
        List<Customer> List(SearchParams filters = null);
        Customer Update(Customer customer);
    }
}