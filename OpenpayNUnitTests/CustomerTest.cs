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
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client " + getRandomWordUpperCase(8);
            customer.LastName = "Technology";
            customer.Email = "net@" + getRandomWordLowerCase(15) + ".com";

            customer = openpayAPI.CustomerService.Create(customer);

            // ---- INI
            string customer_id = customer.Id;
            Customer customerRead = openpayAPI.CustomerService.Get(customer_id);
            Assert.IsNotNull(customerRead);
            Assert.IsNotNull(customerRead.Name);
            Assert.IsNotNull(customerRead.CreationDate);
            Assert.IsNull(customerRead.Address);
            // ---- END

            openpayAPI.CustomerService.Delete(customer_id);
        }

        [Test()]
        public void TestCustomer_List()
        {
            SearchParams search = new SearchParams();
            search.Limit = 3;
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            List<Customer> customers = openpayAPI.CustomerService.List(search);
            Assert.IsNotNull(customers);
            Assert.AreEqual(3, customers.Count);
        }

		[Test()]
        public void TestCustomer_CreateAndDelete()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client " + getRandomWordUpperCase(8);
            customer.LastName = "Technology";
            customer.Email = "net@" + getRandomWordLowerCase(15) + ".com";

            customer = openpayAPI.CustomerService.Create(customer);
            Assert.IsNotNull(customer);
            Assert.IsFalse(String.IsNullOrEmpty(customer.Id));
            openpayAPI.CustomerService.Delete(customer.Id);
        }

		[Test()]
        public void TestCustomer_CreateAndDeleteWithAddress()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
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
            // Create Customer
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client " + getRandomWordUpperCase(8);
            customer.LastName = "Technology";
            customer.Email = "net@" + getRandomWordLowerCase(15) + ".com";

            customer = openpayAPI.CustomerService.Create(customer);

            // --- INI
            Random rnd = new Random();
            string updateName = "New name " + rnd.Next(0, 500);

            string customer_id = customer.Id;
            Customer customerToUpdate = openpayAPI.CustomerService.Get(customer_id);
            customerToUpdate.Name = updateName;

            Customer customerUpdated = openpayAPI.CustomerService.Update(customerToUpdate);
            Assert.IsNotNull(customerUpdated);
            Assert.True(customerUpdated.Name.Contains("New name "));
            // --- FIN

        }

        private String getRandomNumberAsString(int min, int max)
        {
            return String.Concat(new Random().Next(100, 999));
        }

        private String getRandomWordLowerCase(int length)
        {
            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < length; i++)
            {
                text = string.Concat(text, (char)rnd.Next('a', 'z'));
            }
            return text.ToLower();
        }

        private String getRandomWordUpperCase(int length)
        {
            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < length; i++)
            {
                text = string.Concat(text, (char)rnd.Next('a', 'z'));
            }
            return text.ToUpper();
        }

    }
}
