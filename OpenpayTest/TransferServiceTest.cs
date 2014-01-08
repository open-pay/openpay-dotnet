using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class TransferServiceTest
    {
        private static readonly string customer_id = "adyytoegxm6boiusecxm";

        [TestMethod]
        public void TesTransferCreate()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            TransferRequest request = new TransferRequest();
            request.CustomerId = "acjpcdct4tbyemirw7zo";
            request.Amount = 11.0m;
            request.Description = "Transfer Testing";

            Transfer transfer = openpayAPI.TransferService.Create(customer_id, request);
            Assert.IsNotNull(transfer.Id);
            Assert.IsNotNull(transfer.CreationDate);

            Transfer transferGet = openpayAPI.TransferService.Get(customer_id, transfer.Id);
            Assert.AreEqual(transfer.Amount, transferGet.Amount);
            Assert.IsNull(transferGet.OrderId);

            Assert.IsNotNull(transferGet.CreationDate);
            Assert.IsNotNull(transferGet.CustomerId);
            Assert.IsNotNull(transferGet.Description);
            Assert.IsNotNull(transferGet.Method);
            Assert.IsNotNull(transferGet.OperationType);
            Assert.IsNotNull(transferGet.Status);
        }

        [TestMethod]
        public void TesTransferList()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            SearchParams filters = new SearchParams();
            filters.CreationLte = new DateTime(2014, 1, 8);
            filters.Amount = 10.0m;
            List<Transfer> transfers =  openpayAPI.TransferService.List(customer_id, filters);
            Assert.AreEqual(2, transfers.Count);
        }
    }
}
