using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class ChargeServiceTest
    {
        [TestMethod]
        public void TestChargeToCustomerWithSourceId()
        {
            string customer_id = "adyytoegxm6boiusecxm";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = "kwkoqpg6fcvfse8k8mg2";
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(9.99);

            Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
            
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);

            Charge charge2 = openpayAPI.ChargeService.Get(customer_id, charge.Id);
            Assert.IsNotNull(charge2);
            Assert.AreEqual(charge.Id, charge2.Id);
            Assert.AreEqual(charge.Amount, charge2.Amount);
        }

        [TestMethod]
        public void TestChargeToCustomerWithCard()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = GetCardInfo();
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(9.99);

            Charge charge = openpayAPI.ChargeService.Create("adyytoegxm6boiusecxm", request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);
        }

		[TestMethod]
		public void TestChargeToCustomerWithCard_metdatata_USD()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

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

        [TestMethod]
        public void TestChargeToCustomer_AndCapture()
        {
            String customer_id = "adyytoegxm6boiusecxm";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = "kwkoqpg6fcvfse8k8mg2";
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(9.99);
            request.Capture = false;

            Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("in_progress", charge.Status);

            Charge chargeCompleted = openpayAPI.ChargeService.Capture(customer_id, charge.Id, null);
            Assert.IsNotNull(chargeCompleted);
            Assert.AreEqual("completed", chargeCompleted.Status);
            Assert.AreEqual(charge.Amount, chargeCompleted.Amount);
        }

        [TestMethod]
        public void TestChargeToCustomerWithSourceId_AndRefund()
        {
            String customer_id = "adyytoegxm6boiusecxm";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";                                                                                                                                                                                                                                                                                                    
            request.SourceId = "kwkoqpg6fcvfse8k8mg2";
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(9.99);

            Charge charge = openpayAPI.ChargeService.Create(customer_id, request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);

            Charge chargeWithrefund = openpayAPI.ChargeService.Refund(customer_id, charge.Id, "refund desc");
            Assert.IsNotNull(chargeWithrefund);
            Assert.IsNotNull(chargeWithrefund.Refund);
        }

        [TestMethod]
        public void TestChargeToCustomerWithBankAccount()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "bank_account";
            request.Description = "Testing from .Net [BankAccount]";
            request.Amount = new Decimal(9.99);
            request.DueDate = new DateTime(2015, 12, 6, 11, 50, 0);

            Charge charge = openpayAPI.ChargeService.Create("adyytoegxm6boiusecxm", request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.IsNotNull(charge.PaymentMethod);
            Assert.AreEqual("in_progress", charge.Status);
        }
        
        [TestMethod]
        public void TestChargeToCustomerWithStore()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "store";
            request.Description = "Testing from .Net [STORE]";
            request.Amount = new Decimal(9.99);
            request.DueDate = new DateTime(2015,12,6,11,50,0);

            Charge charge = openpayAPI.ChargeService.Create("adyytoegxm6boiusecxm", request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.IsNotNull(charge.PaymentMethod);
            Assert.IsNotNull(charge.PaymentMethod.Reference);
            Assert.AreEqual("in_progress", charge.Status);
        }

        [TestMethod]
        public void TestChargeToCustomerWithBitcoin()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "bitcoin";
            request.Description = "Testing from .Net [BITCOIN]";
            request.Amount = new Decimal(9.99);

            Charge charge = openpayAPI.ChargeService.Create("a48ssup67h74sagrwfwz", request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.IsNotNull(charge.PaymentMethod);
            Assert.IsNotNull(charge.PaymentMethod.AmountBitcoins);
            Assert.IsNotNull(charge.PaymentMethod.PaymentAddress);
            Assert.IsNotNull(charge.PaymentMethod.PaymentUrlBip21);
            Assert.IsNotNull(charge.PaymentMethod.ExchangeRate);
            Assert.AreEqual("bitcoin", charge.PaymentMethod.Type);
            Assert.AreEqual("charge_pending", charge.Status);
        }

        [TestMethod]
        public void TestChargeToMerchant()
        {
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = GetCardInfo();
            request.Description = "Testing from .Net with new card";
            request.Amount = new Decimal(9.99);

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            request.Customer = customer;

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNull(charge.CardPoints);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);

            Charge charge2 = openpayAPI.ChargeService.Get(charge.Id);
            Assert.IsNotNull(charge2);
            Assert.IsNull(charge2.CardPoints);
            Assert.AreEqual(charge.Id, charge2.Id);
            Assert.AreEqual(charge.Amount, charge2.Amount);
        }

        [TestMethod]
        public void TestChargeToMerchantWithPointsSmall()
        {
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = GetCardInfo();
            request.Description = "Testing from .Net with new card";
            request.Amount = new Decimal(9.99);
            request.UseCardPoints = true;

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            request.Customer = customer;

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CardPoints);
            Assert.AreEqual(charge.CardPoints.Amount, new Decimal(9.99));

            Charge charge2 = openpayAPI.ChargeService.Get(charge.Id);
            Assert.IsNotNull(charge2);
            Assert.IsNotNull(charge2.CardPoints);
            Assert.AreEqual(charge.Id, charge2.Id);
            Assert.AreEqual(charge.Amount, charge2.Amount);
            Assert.AreEqual(charge2.CardPoints.Amount, new Decimal(9.99));
        }

        [TestMethod]
        public void TestChargeToMerchantWithPointsBig()
        {
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = GetCardInfo();
            request.Description = "Testing from .Net with new card";
            request.Amount = new Decimal(29.99);
            request.UseCardPoints = true;

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            request.Customer = customer;

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CardPoints);
            Assert.AreEqual(charge.CardPoints.Amount, new Decimal(22.5));

            Charge charge2 = openpayAPI.ChargeService.Get(charge.Id);
            Assert.IsNotNull(charge2);
            Assert.IsNotNull(charge2.CardPoints);
            Assert.AreEqual(charge.Id, charge2.Id);
            Assert.AreEqual(charge.Amount, charge2.Amount);
            Assert.AreEqual(charge2.CardPoints.Amount, new Decimal(22.5));
        }

        [TestMethod]
        public void TestChargeToMerchantAndGetByOrderId()
        {
            Random random = new Random();
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = GetCardInfo();
            request.OrderId = random.Next(0, 10000000).ToString();
            request.Description = "Testing from .Net with new card";
            request.Amount = new Decimal(9.99);

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            request.Customer = customer;

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);

            SearchParams search = new SearchParams();
            search.OrderId = request.OrderId;
            List<Charge> charges = openpayAPI.ChargeService.List(search);
            Assert.AreEqual(1, charges.Count);
            Assert.AreEqual(charge.Id, charges[0].Id);
        }

        [TestMethod]
        public void TestChargeToMerchantAndRefund()
        {
            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = GetCardInfo();
            request.Description = "Testing from .Net with new card";
            request.Amount = new Decimal(9.99);

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);

            Charge refund = openpayAPI.ChargeService.Refund(charge.Id, "Merchant Refund");
            Assert.IsNotNull(refund);
            Assert.IsNotNull(refund.Refund);
        }

        [TestMethod]
        public void TestMerchantChargeWithStore()
        {
            ChargeRequest request = new ChargeRequest();
            request.Method = "store";
            request.Description = "Testing from .Net [STORE]";
            request.Amount = new Decimal(9.99);

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.AreEqual("in_progress", charge.Status);
        }

        [TestMethod]
        public void TestMerchantChargeWithBitcoin()
        {
            ChargeRequest request = new ChargeRequest();
            request.Method = "bitcoin";
            request.Description = "Testing from .Net [BITCOIN]";
            request.Amount = new Decimal(9.99);

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.PaymentMethod);
            Assert.IsNotNull(charge.PaymentMethod.AmountBitcoins);
            Assert.IsNotNull(charge.PaymentMethod.PaymentAddress);
            Assert.IsNotNull(charge.PaymentMethod.PaymentUrlBip21);
            Assert.IsNotNull(charge.PaymentMethod.ExchangeRate);
            Assert.AreEqual("bitcoin", charge.PaymentMethod.Type);
            Assert.AreEqual("charge_pending", charge.Status);
        }

        [TestMethod]
        public void TestMerchantList()
        {
            SearchParams search = new SearchParams();
            search.CreationLte = new DateTime(2014, 1, 7);
            search.Amount = 9.99M;
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            List<Charge> charges= openpayAPI.ChargeService.List(search);
            Assert.AreEqual(3, charges.Count);
            foreach (Charge charge in charges)
            {
                Assert.AreEqual(true, charge.Conciliated);
            }
        }

        public Card GetCardInfo()
        {
            Card card = new Card();
            card.CardNumber = "5555555555554444";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "18";
            return card;
        }
    }
}
