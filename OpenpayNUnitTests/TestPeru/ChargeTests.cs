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
        public void ListAll()
        {
            List<Charge> charges = openpayAPI.ChargeService.List();
            Assert.NotNull(charges);
        }

        [Test()]
        public void Create()
        {
            Card card = openpayAPI.CardService.Create(GetCardInfo());
            List<Customer> customers = openpayAPI.CustomerService.List();
            Customer customer = customers[0];
            customer.ExternalId = null;
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(215.00);
            request.Currency = "PEN";
            request.Customer = customer;
            request.DeviceSessionId = GetId();
            Charge newCharge = openpayAPI.ChargeService.Create(request);
            Assert.NotNull(newCharge);
        }
        
        [Test()]
        public void CreateWithToken()
        {
            Card card = openpayAPI.CardService.Create(GetCardInfo());
            List<Customer> customers = openpayAPI.CustomerService.List();
            Customer customer = customers[0];
            customer.ExternalId = null;
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(215.00);
            request.Currency = "PEN";
            request.Customer = customer;
            request.DeviceSessionId = GetId();
            Charge newCharge = openpayAPI.ChargeService.Create(request);
            Assert.NotNull(newCharge);
        }
        
        private Card GetCardInfo()
        {
            Card card = new Card();
            card.CardNumber = "4111111111111111";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "132";
            card.ExpirationMonth = "12";
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            return card;
        }

        private string GetId()
        {
            Random random = new Random();
            return random.Next(11111, 100000).ToString();
        }
    }
}