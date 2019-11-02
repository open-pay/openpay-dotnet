using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;
using System.Numerics;

namespace OpenpayNUnitTests
{
	[TestFixture ()]
    public class CustomerTest
    {

		[Test()]
        public void TestCustomer_Get()
        {
            string customer_id = "adyytoegxm6boiusecxm";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = openpayAPI.CustomerService.Get(customer_id);
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Name);
            Assert.IsNotNull(customer.Store);
            Assert.IsNotNull(customer.CreationDate);
            Assert.IsNull(customer.Address);
            Assert.IsTrue(customer.Balance.CompareTo(8499.00M) > 0);
        }

		[Test()]
        public void TestCustomer_List()
        {
            SearchParams search = new SearchParams();
            search.Limit = 3;
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            List<Customer> customers = openpayAPI.CustomerService.List(search);
            Assert.IsNotNull(customers);
            Assert.AreEqual(3, customers.Count);
        }

		[Test()]
        public void TestCustomer_CreateAndDelete()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client";
            customer.Email = "net@c.com";

            customer = openpayAPI.CustomerService.Create(customer);
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Store);
            Assert.IsFalse(String.IsNullOrEmpty(customer.Id));
            openpayAPI.CustomerService.Delete(customer.Id);
        }

		[Test()]
        public void TestCustomer_CreateAndDeleteWithAddress()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client";
            customer.LastName = "Technology";
            customer.Email = "net@c.com";
            customer.Address = new Address();
            customer.Address.Department = "Medellín";
            customer.Address.City = "Antioquia";
            customer.Address.Additional = "Avenida 11e bis #152-43 Apartamento 508";

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

		[Test()]
        public void TestUpdate()
        {
            Random rnd = new Random();
            string newName = "New name " + rnd.Next(0, 500);

            string customer_id = "adyytoegxm6boiusecxm";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Customer customer = openpayAPI.CustomerService.Get(customer_id);
            customer.Name = newName;

            customer = openpayAPI.CustomerService.Update(customer);
            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Name);
            Assert.AreEqual(newName, customer.Name);
        }
    }
}
