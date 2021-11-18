using System.Collections.Generic;
using NUnit.Framework;
using Openpay;
using Openpay.Entities;

namespace OpenpayNUnitTests.TestPeru
{
    [TestFixture()]
    public class CustomersTests
    {
        OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID,"PE");

        [Test()]
        public void Create()
        {
            Customer customer = new Customer();
            customer.Name = "Juanito";
            customer.LastName = "De Peru";
            customer.Email = "juanito@deperu.com";
            customer.RequiresAccount = false;
            customer.Address = GetAddress();
            Customer addedCustomer = openpayAPI.CustomerService.Create(customer);
            Assert.NotNull(addedCustomer);
        }

        [Test()]
        public void Update()
        {
            Customer customer = openpayAPI.CustomerService.List()[0];
            string newName = "Juan Ejemplo";
            customer.Name = newName;
            Customer updatedCustomer = openpayAPI.CustomerService.Update(customer);
            Assert.AreEqual(newName, updatedCustomer.Name);
        }

        [Test()]
        public void Get()
        {
            Customer customer = openpayAPI.CustomerService.List()[0];
            Customer customer_ = openpayAPI.CustomerService.Get(customer.Id);
            Assert.AreEqual(customer.Id, customer_.Id);
        }

        [Test()]
        public void Delete()
        {
            Customer customer = openpayAPI.CustomerService.List()[0];
            openpayAPI.CustomerService.Delete(customer.Id);
            Assert.Throws<OpenpayException>(delegate
            {
                openpayAPI.CustomerService.Get(customer.Id);
            });
        }

        [Test()]
        public void List()
        {
            List<Customer> customers = openpayAPI.CustomerService.List();
            Assert.NotNull(customers);
        }

        private Address GetAddress()
        {
            Address address = new Address();
            address.City = "Lima";
            address.CountryCode = "PE";
            address.PostalCode = "110511";
            address.Line1 = "Av 5 de Febrero";
            address.Line2 = "Roble 207";
            address.Line3 = "col carrillo";
            address.State = "Lima";
            return address;
        }
    }
}