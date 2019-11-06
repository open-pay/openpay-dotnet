using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayNUnitTests
{
	[TestFixture()]
	public class FeeTest
	{
        /*
		[Test()]
		public void TestFeeAndRefund()
		{
            // Create Customer
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client " + getRandomWordUpperCase(8);
            customer.LastName = "Technology";
            customer.Email = "net@" + getRandomWordLowerCase(15) + ".com";

            customer = openpayAPI.CustomerService.Create(customer);

            // --- INI
            string customerId = customer.Id;
			Decimal amount = new Decimal(11);
			string description = "comisión de .Net de "+ amount;
			string refundDescription = "reembolso de comisión de .Net de "+ amount;

			FeeRequest feeRequest = new FeeRequest();
			feeRequest.CustomerId = customerId;
			feeRequest.Description = description;
			feeRequest.Amount = amount;

			Fee fee = openpayAPI.FeeService.Create(feeRequest);
			Assert.IsNotNull(fee);
			Assert.IsNotNull(fee.Id);
			Assert.IsNotNull(fee.CreationDate);
			Assert.AreEqual("completed", fee.Status);

			Fee refundFee = openpayAPI.FeeService.Refund(fee.Id, refundDescription);
			Assert.IsNotNull(refundFee);
			Assert.IsNotNull(refundFee.Id);
			Assert.IsNotNull(refundFee.CreationDate);
			Assert.AreEqual("completed", refundFee.Status);

            // --- FIN

		}

		[Test()]
        public void TesFeeList()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            SearchParams filters = new SearchParams();
            filters.CreationLte = new DateTime(2014, 1, 8);
            filters.Amount = 6.0m;
            List<Fee> transfers = openpayAPI.FeeService.List(filters);
            Assert.AreEqual(3, transfers.Count);
        }
		
		[Test()]
		public void TestSummary_NoInfo()
		{
			OpenpayAPI api = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, false);
			OpenpayFeesSummary summary = api.OpenpayFeesService.Summary (2012, 03);
			Assert.AreEqual(Decimal.Zero, summary.Charged);
			Assert.AreEqual(Decimal.Zero,summary.ChargedTax);
			Assert.AreEqual(Decimal.Zero,summary.ChargedAdjustments);
			Assert.AreEqual(Decimal.Zero,summary.ChargedAdjustmentsTax);
			Assert.AreEqual(Decimal.Zero,summary.Refunded);
			Assert.AreEqual(Decimal.Zero,summary.RefundedTax);
			Assert.AreEqual(Decimal.Zero,summary.RefundedAdjustments);
			Assert.AreEqual(Decimal.Zero,summary.RefundedAdjustmentsTax);
			Assert.AreEqual(Decimal.Zero,summary.Total);
		}

		[Test()]
		public void TestDetails_NoInfo()
		{
			OpenpayAPI api = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, false);
			List<Transaction> list = api.OpenpayFeesService.Details(2012, 03, "charged", null);
			Assert.AreEqual(0, list.Count);
		}

		[Test()]
		public void TestDetails_Pagination_NoInfo()
		{
			OpenpayAPI api = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, false);
			PaginationParams pagination = new PaginationParams();
			pagination.Limit = 5;
			pagination.Offset = 5;
			List<Transaction> list = api.OpenpayFeesService.Details(2012, 03, "charged", pagination);
			Assert.AreEqual(0, list.Count);
		}
        */

        private String getRandomNumberAsString(int min, int max)
        {
            return String.Concat(new Random().Next(100, 999));
        }

        private String getRandomWordLowerCase(int length)
        {
            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < length; i++)
            {
                text = string.Concat(text, (char)rnd.Next('a', 'z'));
            }
            return text.ToLower();
        }

        private String getRandomWordUpperCase(int length)
        {
            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < length; i++)
            {
                text = string.Concat(text, (char)rnd.Next('a', 'z'));
            }
            return text.ToUpper();
        }

    }
}

