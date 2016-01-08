using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class BankAccountServiceTest
    {
        private static readonly string customer_id = "adyytoegxm6boiusecxm";

        [TestMethod]
        public void TestAsCustomer_CreateGetDelete()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            BankAccount bankAccount = new BankAccount();
			bankAccount.CLABE = "012212000000000006";
            bankAccount.HolderName = "Testing";
            BankAccount bankAccountCreated = openpayAPI.BankAccountService.Create(customer_id, bankAccount);
            Assert.IsNotNull(bankAccountCreated.Id);
            Assert.IsNull(bankAccountCreated.Alias);
            Assert.AreEqual("012XXXXXXXXXX00006", bankAccountCreated.CLABE);

            BankAccount bankAccountGet = openpayAPI.BankAccountService.Get(customer_id, bankAccountCreated.Id);
            Assert.AreEqual("012XXXXXXXXXX00006", bankAccountGet.CLABE);

            List<BankAccount> accounts = openpayAPI.BankAccountService.List(customer_id);
            Assert.AreEqual(1, accounts.Count);

            openpayAPI.BankAccountService.Delete(customer_id, bankAccountGet.Id);
           
        }

       // [TestMethod]
        public void TestAsMerchant_CreateGetDelete()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            string bank_account_id = "bypzo1cstk5xynsuzjxo";

            BankAccount bankAccountGet = openpayAPI.BankAccountService.Get(bank_account_id);
            Assert.AreEqual("012XXXXXXXXXX24616", bankAccountGet.CLABE);

            openpayAPI.BankAccountService.Delete(bankAccountGet.Id);

        }
    }
}
