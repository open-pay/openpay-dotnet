using System;
using System.Collections.Generic;
using NUnit.Framework;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace OpenpayNUnitTests.TestPeru
{
    [TestFixture()]
    public class CheckoutTests
    {
        OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID,"PE");
        
        [Test()]
        public void Create()
        {
            CheckoutRequest checkoutRequest = new CheckoutRequest();
            checkoutRequest.Amount = 100;
            checkoutRequest.Description = "Checkout de prueba";
            checkoutRequest.OrderId = "oid-" + GetId();
            checkoutRequest.Currency = "PEN";
            checkoutRequest.RedirectUrl = "www.miempresa.com";
            Customer customer = openpayAPI.CustomerService.List()[0];
            customer.ExternalId = null;
            customer.CreationDate = null;
            customer.Id = null;
            checkoutRequest.Customer = customer;
            Checkout checkout = openpayAPI.CheckoutService.Create(checkoutRequest);
            Assert.NotNull(checkout);
        }
        
        [Test()]
        public void CreateWithCustomer()
        {
            CheckoutRequest checkoutRequest = new CheckoutRequest();
            checkoutRequest.Amount = 100;
            checkoutRequest.Description = "Checkout de prueba";
            checkoutRequest.OrderId = "oid-" + GetId();
            checkoutRequest.Currency = "PEN";
            checkoutRequest.RedirectUrl = "www.miempresa.com";
            Customer customer = openpayAPI.CustomerService.List()[0];
            Checkout checkout = openpayAPI.CheckoutService.Create(customer.Id, checkoutRequest);
            Assert.NotNull(checkout);
        }

        [Test()]
        public void Get()
        {
            CheckoutRequest checkoutRequest = new CheckoutRequest();
            checkoutRequest.Amount = 100;
            checkoutRequest.Description = "Checkout de prueba";
            checkoutRequest.OrderId = "oid-" + GetId();
            checkoutRequest.Currency = "PEN";
            checkoutRequest.RedirectUrl = "www.miempresa.com";
            Customer customer = openpayAPI.CustomerService.List()[0];
            Checkout checkout = openpayAPI.CheckoutService.Create(customer.Id, checkoutRequest);

            Checkout checkout_ = openpayAPI.CheckoutService.Get(checkout.Id);
            Assert.AreEqual(checkout.Id, checkout_.Id);
        }

        [Test()]
        public void UpdateCheckout()
        {
            CheckoutRequest checkoutRequest = new CheckoutRequest();
            checkoutRequest.Amount = 100;
            checkoutRequest.Description = "Checkout de prueba";
            checkoutRequest.OrderId = "oid-" + GetId();
            checkoutRequest.Currency = "PEN";
            checkoutRequest.RedirectUrl = "www.miempresa.com";
            Customer customer = openpayAPI.CustomerService.List()[0];
            Checkout checkout = openpayAPI.CheckoutService.Create(customer.Id, checkoutRequest);
            UpdateCheckoutRequest newData = new UpdateCheckoutRequest();
            newData.ExpirationDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd HH:mm");
            Checkout updatedCheckout = openpayAPI.CheckoutService.Update(checkout, "available", newData);
            Assert.NotNull(updatedCheckout);
        }

        [Test()]
        public void List()
        {
            SearchParams searchParams = new SearchParams();
            searchParams.Limit = 10;
            searchParams.StartDate = "20211001";
            searchParams.EndDate = "20211011";
            List<Checkout> checkouts = openpayAPI.CheckoutService.List(searchParams);
            Assert.NotNull(checkouts);
        }
        
        private string GetId()
        {
            Random random = new Random();
            return random.Next(11111, 100000).ToString();
        }
    }
}