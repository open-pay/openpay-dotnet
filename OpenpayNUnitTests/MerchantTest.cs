using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;
using System.Numerics;

namespace OpenpayNUnitTests
{
	[TestFixture ()]
    public class MerchantServiceTest
    {

        [Test()]
        public void TestMerchant_Get()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Merchant merchant = openpayAPI.MerchantService.Get();
            Assert.IsNotNull(merchant);
            Assert.IsNotNull(merchant.Name);
            Assert.IsNotNull(merchant.Email);
            Assert.IsNotNull(merchant.CreationDate);
            Assert.IsNotNull(merchant.Status);
            Assert.IsNull(merchant.CLABE);
            Assert.IsNotNull(merchant.Phone);
        }

    }
        
}
