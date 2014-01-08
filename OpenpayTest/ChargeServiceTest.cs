using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace OpenpayTest
{
    [TestClass]
    public class ChargeServiceTest
    {
        [TestMethod]
        public void TestChargeToCustomerWithSourceId()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = "kwkoqpg6fcvfse8k8mg2";
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(9.99);

            Charge charge = openpayAPI.ChargeService.Create(request, "adyytoegxm6boiusecxm");
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);
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

            Charge charge = openpayAPI.ChargeService.Create(request, customer_id);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("in_progress", charge.Status);

            Charge chargeCompleted = openpayAPI.ChargeService.Capture(charge.Id, customer_id);
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

            Charge charge = openpayAPI.ChargeService.Create(request, customer_id);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);

            Charge chargeWithrefund = openpayAPI.ChargeService.Refund(charge.Id, customer_id);
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

            Charge charge = openpayAPI.ChargeService.Create(request, "adyytoegxm6boiusecxm");
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.IsNotNull(charge.PaymentMethod);
            Assert.AreEqual("in_progress", charge.Status);
        }

        [TestMethod]
        public void TestChargeToMerchant()
        {
            Card card = new Card();
            card.CardNumber = "5243385358972033";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "14";

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Card = card;
            request.Description = "Testing from .Net with new card";
            request.Amount = new Decimal(9.99);

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
        }
    }
}
