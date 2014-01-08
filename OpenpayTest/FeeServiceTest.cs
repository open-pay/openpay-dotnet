using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class FeeServiceTest
    {
        private static readonly string customer_id = "adyytoegxm6boiusecxm";

        [TestMethod]
        public void TesFeeCreate()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            FeeRequest request = new FeeRequest();
            request.CustomerId = customer_id;
            request.Amount = 7.0m;
            request.Description = "Fee Testing";

            Fee fee = openpayAPI.FeeService.Create(request);
            Assert.IsNotNull(fee.Id);
            Assert.IsNotNull(fee.CreationDate);
            Assert.IsNotNull(fee.CustomerId);
            Assert.IsNotNull(fee.Description);
            Assert.IsNotNull(fee.Method);
            Assert.IsNotNull(fee.OperationType);
            Assert.IsNotNull(fee.Status);
        }

        [TestMethod]
        public void TesFeeList()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            SearchParams filters = new SearchParams();
            filters.CreationLte = new DateTime(2014, 1, 8);
            filters.Amount = 6.0m;
            List<Fee> transfers = openpayAPI.FeeService.List(filters);
            Assert.AreEqual(3, transfers.Count);
        }
    }
}
