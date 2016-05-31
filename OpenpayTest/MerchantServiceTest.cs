using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class MerchantServiceTest
    {

        [TestMethod]
        public void TestMerchant_Get()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Merchant merchant = openpayAPI.MerchantService.Get();
            Assert.IsNotNull(merchant);
            Assert.IsNotNull(merchant.Name);
            Assert.IsNotNull(merchant.Email);
            Assert.IsNotNull(merchant.CreationDate);
            Assert.IsNotNull(merchant.Status);
            Assert.IsNotNull(merchant.CLABE);
            Assert.IsNotNull(merchant.Phone);
            Assert.IsTrue(merchant.Balance.CompareTo(1000.00M) > 0);
            Assert.IsTrue(merchant.AvailableFunds.CompareTo(1000.00M) > 0);
        }

    }
        
}
