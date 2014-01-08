using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class CustomerServiceTest
    {

        [TestMethod]
        public void TestCustomer_Get()
        {
            string customer_id = "adyytoegxm6boiusecxm";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = openpayAPI.CustomerService.Get(customer_id);
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Name);
            Assert.IsNotNull(customer.CreationDate);
            Assert.IsNull(customer.Address);
            Assert.IsTrue(customer.Balance.CompareTo(8499.00M) > 0);
        }

        [TestMethod]
        public void TestCustomer_List()
        {
            SearchParams search = new SearchParams();
            search.Limit = 3;
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            List<Customer> customers = openpayAPI.CustomerService.List(search);
            Assert.IsNotNull(customers);
            Assert.AreEqual(3, customers.Count);
        }

        [TestMethod]
        public void TestCustomer_CreateAndDelete()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client";
            customer.Email = "net@c.com";

            customer = openpayAPI.CustomerService.Create(customer);
            Assert.IsNotNull(customer);
            Assert.IsFalse(String.IsNullOrEmpty(customer.Id));
            openpayAPI.CustomerService.Delete(customer.Id);
        }

        [TestMethod]
        public void TestCustomer_CreateAndDeleteWithAddress()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client";
            customer.LastName = "C#";
            customer.Email = "net@c.com";
            customer.Address = new Address();
            customer.Address.Line1 = "line 1";
            customer.Address.PostalCode = "12355";
            customer.Address.City = "Queretaro";
            customer.Address.CountryCode = "MX";
            customer.Address.State = "Queretaro";

            customer = openpayAPI.CustomerService.Create(customer);
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Address);
            Assert.IsFalse(String.IsNullOrEmpty(customer.Id));
            Assert.AreEqual("Net Client", customer.Name);

            openpayAPI.CustomerService.Delete(customer.Id);

            try
            {
                openpayAPI.CustomerService.Get(customer.Id);
                Assert.Fail("No deberia existir");
            }
            catch (OpenpayException e)
            {
                Assert.IsNotNull(e.Description);
            }
        }

        [TestMethod]
        public void TestUpdate()
        {
            Random rnd = new Random();
            string newName = "New name " + rnd.Next(0, 500);

            string customer_id = "adyytoegxm6boiusecxm";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = openpayAPI.CustomerService.Get(customer_id);
            customer.Name = newName;

            customer = openpayAPI.CustomerService.Update(customer.Id, customer);
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Name);
            Assert.AreEqual(newName, customer.Name);
        }
    }
}
