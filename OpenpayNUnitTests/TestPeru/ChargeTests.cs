using System;
using System.Collections.Generic;
using NUnit.Framework;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace OpenpayNUnitTests.TestPeru
{
    [TestFixture()]
    public class ChargeTests
    {
        OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID,"PE");

        [Test()]
        public void CreateWithToken()
        {
            Token token = getToken();
            ChargeRequest newCharge = new ChargeRequest();
            newCharge.Method = "card";
            newCharge.SourceId = token.Id;
            newCharge.Amount = 100;
            newCharge.Currency = "PEN";
            newCharge.Description = "Cargo de prueba";
            newCharge.OrderId = "oid-" + GetId();
            newCharge.DeviceSessionId = token.Id;
            Customer customer = new Customer();
            customer.Name = "Cliente Perú";
            customer.LastName = "Vazquez Juarez";
            customer.PhoneNumber = "4448936475";
            customer.Email = "juan.vazquez@empresa.pe";
            newCharge.Customer = customer;

            Charge charge = openpayAPI.ChargeService.Create(newCharge);
            Assert.NotNull(charge);
        }

        [Test()]
        public void CreateWithCustomer()
        {
            Token token = getToken();
            ChargeRequest newCharge = new ChargeRequest();
            newCharge.Method = "card";
            newCharge.SourceId = token.Id;
            newCharge.Amount = 100;
            newCharge.Currency = "PEN";
            newCharge.Description = "Cargo de prueba";
            newCharge.OrderId = "oid-" + GetId();
            newCharge.DeviceSessionId = token.Id;

            Customer customer = openpayAPI.CustomerService.List()[0];
            
            Charge charge = openpayAPI.ChargeService.Create(customer.Id,newCharge);
            Assert.NotNull(charge);
        }
        
        [Test()]
        public void CreateWithRedirection()
        {
            ChargeRequest newCharge = new ChargeRequest();
            newCharge.Method = "card";
            newCharge.SourceId = null;
            newCharge.Amount = 100;
            newCharge.Currency = "PEN";
            newCharge.Description = "Cargo de prueba";
            newCharge.OrderId = "oid-" + GetId();
            newCharge.DeviceSessionId = null;
            Customer customer = new Customer();
            customer.Name = "Cliente Perú";
            customer.LastName = "Vazquez Juarez";
            customer.PhoneNumber = "4448936475";
            customer.Email = "juan.vazquez@empresa.pe";
            newCharge.Customer = customer;
            newCharge.Confirm = "false";
            newCharge.RedirectUrl = "www.miempresa.pe";

            Charge charge = openpayAPI.ChargeService.Create(newCharge);
            Assert.NotNull(charge);
        }
        
        [Test()]
        public void CreateStoreCharge()
        {
            ChargeRequest newCharge = new ChargeRequest();
            newCharge.Method = "store";
            newCharge.SourceId = null;
            newCharge.Amount = 100;
            newCharge.Currency = "PEN";
            newCharge.Description = "Cargo de prueba";
            newCharge.OrderId = "oid-" + GetId();
            newCharge.DeviceSessionId = null;
            Customer customer = new Customer();
            customer.Name = "Cliente Perú";
            customer.LastName = "Vazquez Juarez";
            customer.PhoneNumber = "4448936475";
            customer.Email = "juan.vazquez@empresa.pe";
            newCharge.Customer = customer;
            newCharge.Confirm = "false";
            newCharge.RedirectUrl = "www.miempresa.pe";

            Charge charge = openpayAPI.ChargeService.Create(newCharge);
            Assert.NotNull(charge);
        }

        [Test()]
        public void Get()
        {
            List<Charge> charges = openpayAPI.ChargeService.List();
            Charge charge = openpayAPI.ChargeService.Get(charges[0].Id);
            Assert.NotNull(charge);
            Assert.AreEqual(charge.Id, charges[0].Id);
        }
        
        [Test()]
        public void ListAll()
        {
            SearchParams searchParams = new SearchParams();
            searchParams.Amount = 100;
            List<Charge> charges = openpayAPI.ChargeService.List(searchParams);
            Assert.NotNull(charges);
        }

        private Token getToken()
        {
            TokenRequest tokenRequest = new TokenRequest();
            tokenRequest.CardNumber = "4111111111111111";
            tokenRequest.HolderName = "Juan Perez Ramirez";
            tokenRequest.ExpirationYear = "21";
            tokenRequest.ExpirationMonth = "12";
            tokenRequest.Cvv2 = "110";
            Address address = new Address();
            address.City = "Lima";
            address.CountryCode = "PE";
            address.PostalCode = "110511";
            address.Line1 = "Av 5 de Febrero";
            address.Line2 = "Roble 207";
            address.Line3 = "col carrillo";
            address.State = "Lima";
            tokenRequest.Address = address;

            return openpayAPI.TokenService.Create(tokenRequest);
        }

        private string GetId()
        {
            Random random = new Random();
            return random.Next(11111, 100000).ToString();
        }
    }
}