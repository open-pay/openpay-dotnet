using System;
using System.Collections.Generic;
using NUnit.Framework;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace OpenpayNUnitTests
{
    [TestFixture()]
    public class CustomerServiceTest
    {
        [Test()]
        public void TestCustomer_List()
        {
            SearchParams search = new SearchParams();
            search.Limit = 3;
            search.AmountGte = Decimal.One;
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            List<Customer> customers = openpayAPI.CustomerService.List(search);
            Assert.IsNotNull(customers);
            Assert.AreEqual(3, customers.Count);
        }
        
    }
}