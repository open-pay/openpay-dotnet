﻿using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;
using System.Numerics;

namespace OpenpayNUnitTests
{
    [TestFixture()]
    public class ChargeTest
    {
        [Test()]
        public void TestGetByOrderId()
        {
            string orderId = "mono3-scoti-oid-00006";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, Constants.PublicIp);

            SearchParams search = new SearchParams();
            search.OrderId = orderId;
            search.Status = TransactionStatus.REFUNDED;
            search.CreationGte = new DateTime(2016, 9, 7);
            search.CreationLte = new DateTime(2016, 10, 1);
            List<Charge> charges = openpayAPI.ChargeService.List(search);

            Console.WriteLine("charges: " + charges.ToArray());

            Assert.IsNotNull(charges);
            Assert.AreEqual(1, charges.Count);
        }

        [Test()]
        public void TestCharge()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            Card card = openpayAPI.CardService.Create(GetCardInfo());

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(111.00);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Console.WriteLine("before charge: ");
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);
        }

        [Test()]
        public void TestChargeToComerceWithCustomer()
        {
            OpenpayAPI openpayApi = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            Card card = openpayApi.CardService.Create(GetCardInfo());
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(230.00);
            Customer customer = new Customer();
            customer.Name = "marco";
            customer.LastName = "morales";
            customer.PhoneNumber = "111111111";
            customer.Email = "marco@me.com";
            request.Customer = customer;
            Charge charge = openpayApi.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Customer);
            Assert.IsNotNull(charge.Customer.Name);
            Assert.IsNotNull(charge.Customer.LastName);
            Assert.IsNotNull(charge.Customer.PhoneNumber);
            Assert.IsNotNull(charge.Customer.Email);
            Assert.AreEqual(charge.Customer.Name,"marco");
            Assert.AreEqual(charge.Customer.LastName,"morales");
        }
        
        [Test()]
        public void GetCharge()
        {
            OpenpayAPI api = new OpenpayAPI("sk_e568c42a6c384b7ab02cd47d2e407cab", "mzdtln0bmtms6o3kck8f", Constants.PublicIp);
            // ChargeRequest request = new ChargeRequest();
            // request.Method = "bank_account";
            // request.Amount = new Decimal(100.00);
            // request.Description = "Cargo con banco";
            // request.OrderId = "qrsof-002";
            // Charge charge = api.ChargeService.Create(request);
            // Console.Write(charge);
            
            List<Charge> charges = api.ChargeService.List();
            Console.Write(charges.Count);

        }
        
        

        [Test()]
        public void TestCancelCharge()
        {
            string customer_id = "aa8ekxqmzcwyxugli0h1";
            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";
            customer.Id = customer_id;

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            Card card = openpayAPI.CardService.Create(GetCardInfo());

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(111.00);
            request.Use3DSecure = true;
            request.RedirectUrl = "https://www.openpay.mx";
            request.Customer = customer;
            request.Confirm = "false";
            request.SendEmail = false;
            request.DeviceSessionId = "kR1MiQhz2otdIuUlQkbEyitIqVMiI16f";

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.IsNotNull(charge.PaymentMethod.Url);
            Assert.AreEqual("charge_pending", charge.Status);

            charge = openpayAPI.ChargeService.CancelByMerchant(Constants.MERCHANT_ID, charge.Id, request);
            Assert.IsNotNull(charge);
            Assert.AreEqual("cancelled", charge.Status);
        }

        [Test()]
        public void TestCharge3DSecure()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            Card card = openpayAPI.CardService.Create(GetCardInfo());

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(111.00);
            request.Use3DSecure = true;
            request.RedirectUrl = "https://www.openpay.mx";


            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.IsNotNull(charge.PaymentMethod.Url);
            Assert.AreEqual("charge_pending", charge.Status);
        }

        [Test()]
        public void TestRefundCharge()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, Constants.PublicIp);
            Card card = openpayAPI.CardService.Create(GetScotiaCardInfo());

            SearchParams searh = new SearchParams();
            List<Customer> customers = openpayAPI.CustomerService.List(searh);
            Customer customer = customers[0];
            customer.ExternalId = null;

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(111.00);
            request.DeviceSessionId = "sah2e76qfdqa72ef2e2q";
            request.Customer = customer;

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);

            Decimal refundAmount = charge.Amount;
            string description = "reembolso desce .Net de " + refundAmount;

            Charge refund = openpayAPI.ChargeService.Refund(charge.Id, description, refundAmount);

            Assert.IsNotNull(refund);
            Assert.IsNotNull(refund.Id);
            Assert.IsNotNull(refund.CreationDate);
            Assert.AreEqual("completed", refund.Status);
        }

        [Test()]
        public void TestRefundChargeWithRequest()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, Constants.PublicIp);
            Card card = openpayAPI.CardService.Create(GetScotiaCardInfo());

            SearchParams searh = new SearchParams();
            List<Customer> customers = openpayAPI.CustomerService.List(searh);
            Customer customer = customers[0];
            customer.ExternalId = null;

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(111.00);
            request.DeviceSessionId = "sah2e76qfdqa72ef2e2q";
            request.Customer = customer;

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);

            Decimal refundAmount = charge.Amount;
            string description = "reembolso desce .Net de " + refundAmount;

            RefundRequest refundRequest = new RefundRequest();
            refundRequest.Description = description;
            refundRequest.Amount = refundAmount;
            // refundRequest.Gateway = 

            Charge refund = openpayAPI.ChargeService.RefundWithRequest(charge.Id, refundRequest);

            Assert.IsNotNull(refund);
            Assert.IsNotNull(refund.Id);
            Assert.IsNotNull(refund.CreationDate);
            Assert.AreEqual("completed", refund.Status);
        }

        [Test()]
        public void TestRedirectCharge()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, Constants.PublicIp);

            SearchParams searh = new SearchParams();
            List<Customer> customers = openpayAPI.CustomerService.List(searh);
            Customer customer = customers[0];
            customer.ExternalId = null;

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Description = "Testing redirect from .Net";
            request.Amount = new Decimal(111.00);
            request.DeviceSessionId = "sah2e76qfdqa72ef2e2q";
            request.Customer = customer;
            request.Confirm = "false";
            request.SendEmail = true;
            request.RedirectUrl = "http://www.openpay.mx/index.html";

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("charge_pending", charge.Status);
            Console.WriteLine("Url: " + charge.PaymentMethod.Url);
        }

        [Test()]
        public void TestPointsBalance()
        {
            //string customerExternaiId = "monos003_customer001";
            String customer_id = "asda4znfoxhvpgcsui3q";
            String card_id = "keqctdqbro2b7jtcnz7d";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, Constants.PublicIp);
            //Card card = openpayAPI.CardService.Create(GetScotiaCardInfo());

            PointsBalance pointsBalance = openpayAPI.CardService.Points(customer_id, card_id);

            Assert.IsNotNull(pointsBalance);
            Assert.AreEqual(new BigInteger(450), pointsBalance.RemainingPoints);
            Assert.AreEqual(new Decimal(33.75), pointsBalance.RemainingMxn);
            Assert.AreEqual(PointsType.BANCOMER, pointsBalance.PointsTypeEnum);

            Console.WriteLine("pointsBalance:[remaining Mx:" + pointsBalance.RemainingMxn + ", remainingPoints:" +
                              pointsBalance.RemainingPoints + "]");
        }

        [Test()]
        public void TestSantanderPoints()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            Card card = openpayAPI.CardService.Create(GetCardInfo());

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(215.00);
            request.UseCardPoints = UseCardPointsType.MIXED.ToString();

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);
        }

        [Test()]
        public void TestChargeWithCodiOptions()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI("sk_5ed6b8da2ace43db89efa8706b3b6e7f","m4ler8bdfpwnttgflt5n", Constants.PublicIp);
            ChargeRequest request = new ChargeRequest();
            request.Method = "codi";
            request.Amount = new Decimal(200.00);
            request.Description = "Testing from .Net Codi";
            DateTime time = new DateTime(2021, 12, 20);
            request.DueDate = time;
            CodiOptions codiOptions = getCodiOptions();
            request.CodiOptions = codiOptions;
            Customer customer = getCustomer();
            request.Customer = customer;
            Charge charge = openpayAPI.ChargeService.Create(request);
            Console.Out.WriteLine("CHARGE");
            Console.Out.WriteLine(charge);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("charge_pending", charge.Status);
            Assert.AreEqual("codi", charge.PaymentMethod.Type);
            Assert.AreEqual("codi", charge.Method);
            Assert.IsNotNull(charge.PaymentMethod.BarcodeURL);
        }

        
        [Test()]
        public void TestChargeToCustomerWithCard_metdatata_USD()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = GetCardInfo();
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(9.99);
            request.Metadata = new Dictionary<string, string> ();
            request.Metadata.Add ("test_key1", "pruebas");
            request.Metadata.Add ("test_key2", "123456");
            request.Currency = "USD";

            Charge charge = openpayAPI.ChargeService.Create("adyytoegxm6boiusecxm", request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);
            Assert.IsNotNull(charge.Metadata);
            Assert.IsNotNull(charge.ExchangeRate);
        }
        
        [Test()]
        public void TestChargeToCustomerWithStore()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            ChargeRequest request = new ChargeRequest();
            request.Method = "store";
            request.Description = "Testing from .Net [STORE]";
            request.Amount = new Decimal(9.99);
            request.DueDate = DateTime.Now.AddDays(25);
            Charge charge = openpayAPI.ChargeService.Create("adyytoegxm6boiusecxm", request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.IsNotNull(charge.PaymentMethod);
            Assert.IsNotNull(charge.PaymentMethod.Reference);
            Assert.AreEqual("in_progress", charge.Status);
        }
        
        public void TestChargeWithAffiliation()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, Constants.PublicIp);
            Card card = openpayAPI.CardService.Create(GetCardInfo());

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(215.00);

            Affiliation affiliation = new Affiliation();
            affiliation.Name = "amex_3d";
            request.Affiliation = affiliation;

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);
        }

        public Card GetCardInfo()
        {
            Card card = new Card();
            card.CardNumber = "5555555555554444";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "132";
            card.ExpirationMonth = "12";
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            return card;
        }

        public Card GetScotiaCardInfo()
        {
            Card card = new Card();
            card.CardNumber = "5105105105105100";
            card.HolderName = "Aquiles Salto Ramon";
            card.Cvv2 = "123";
            card.ExpirationMonth = "12";
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            return card;
        }

        public Customer getCustomer()
        {
            Customer customer = new Customer();
            customer.Name = "Marco";
            customer.LastName = "Morales";
            customer.Email = "this.is.a@customer.test";
            customer.PhoneNumber = "7711234567";
            return customer;
        }

        public CodiOptions getCodiOptions()
        {
            CodiOptions codiOptions = new CodiOptions();
            codiOptions.Mode = "qr_code";
            return codiOptions;
        }
        
        
    }
}