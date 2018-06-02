using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class PayoutServiceTest
    {
        string customer_id = "adyytoegxm6boiusecxm";
        /*
        [TestMethod]
        public void TestPayoutAsCustomer_CreateBankAccount()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            BankAccount bankAccount = new BankAccount();
            bankAccount.CLABE = "012298026516924616";
            bankAccount.HolderName = "Testing";

            PayoutRequest request = new PayoutRequest();
            request.Method = "bank_account";
            request.BankAccount = bankAccount;
            request.Amount = 8.5m;
            request.Description = "Payout test";
            Payout payout = openpayAPI.PayoutService.Create(customer_id, request);
            Assert.IsNotNull(payout.Id);
            Assert.IsNotNull(payout.CreationDate);
            Assert.IsNotNull(payout.BankAccount);

            Payout payoutGet = openpayAPI.PayoutService.Get(customer_id, payout.Id);
            Assert.AreEqual(payout.Amount, payoutGet.Amount);
            Assert.AreEqual(payout.BankAccount.CLABE, payoutGet.BankAccount.CLABE);
        }

        [TestMethod]
        public void TestPayoutAsCustomer_CreateWithNewBankAccount()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            BankAccount bankAccount = new BankAccount();
			bankAccount.CLABE = "012212000000000019";
            bankAccount.HolderName = "Testing";

            bankAccount = openpayAPI.BankAccountService.Create(customer_id, bankAccount);

            PayoutRequest request = new PayoutRequest();
            request.Method = "bank_account";
            request.DestinationId = bankAccount.Id;
            request.Amount = 8.5m;
            request.Description = "Payout test";
            Payout payout = openpayAPI.PayoutService.Create(customer_id, request);
            Assert.IsNotNull(payout.Id);
            Assert.IsNotNull(payout.CreationDate);
            Assert.IsNotNull(payout.BankAccount);

            Payout payoutGet = openpayAPI.PayoutService.Get(customer_id, payout.Id);
            Assert.AreEqual(payout.Amount, payoutGet.Amount);
            Assert.AreEqual(payout.BankAccount.CLABE, payoutGet.BankAccount.CLABE);

            openpayAPI.BankAccountService.Delete(customer_id, bankAccount.Id);
        }

        [TestMethod]
        public void TestPayoutAsCustomer_CreateCard()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Card card = new Card();
            card.CardNumber = "4111111111111111";
            card.BankCode = "002";
            card.HolderName = "Payout User";


            PayoutRequest request = new PayoutRequest();
            request.Method = "card";
            request.Card = card;
            request.Amount = 5.5m;
            request.Description = "Payout test";
            Payout payout = openpayAPI.PayoutService.Create(customer_id, request);
            Assert.IsNotNull(payout.Id);
            Assert.IsNotNull(payout.CreationDate);
            Assert.IsNotNull(payout.Card);
            Assert.IsNull(payout.BankAccount);

            Payout payoutGet = openpayAPI.PayoutService.Get(customer_id, payout.Id);
            Assert.AreEqual(payout.Amount, payoutGet.Amount);
        }

        [TestMethod]
        public void TestPayoutAsMerchant_CreateCard()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Card card = new Card();
            card.CardNumber = "4111111111111111";
            card.BankCode = "002";
            card.HolderName = "Payout User";


            PayoutRequest request = new PayoutRequest();
            request.Method = "card";
            request.Card = card;
            request.Amount = 5.5m;
            request.Description = "Payout test";
            Payout payout = openpayAPI.PayoutService.Create(request);
            Assert.IsNotNull(payout.Id);
            Assert.IsNotNull(payout.CreationDate);
            Assert.IsNotNull(payout.Card);
            Assert.IsNull(payout.BankAccount);

            Payout payoutGet = openpayAPI.PayoutService.Get(payout.Id);
            Assert.AreEqual(payout.Amount, payoutGet.Amount);
        }


        [TestMethod]
        public void TestPayoutAsMerchant_CreateBankAccount()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            BankAccount bankAccount = new BankAccount();
            bankAccount.CLABE = "012298026516924616";
            bankAccount.HolderName = "Testing";

            PayoutRequest request = new PayoutRequest();
            request.Method = "bank_account";
            request.BankAccount = bankAccount;
            request.Amount = 8.5m;
            request.Description = "Payout test";
            Payout payout = openpayAPI.PayoutService.Create(request);
            Assert.IsNotNull(payout.Id);
            Assert.IsNotNull(payout.CreationDate);
            Assert.IsNotNull(payout.BankAccount);

            Payout payoutGet = openpayAPI.PayoutService.Get(payout.Id);
            Assert.AreEqual(payout.Amount, payoutGet.Amount);
            Assert.AreEqual(payout.BankAccount.CLABE, payoutGet.BankAccount.CLABE);
        }
        */
    }
}
