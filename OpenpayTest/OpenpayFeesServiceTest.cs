using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayTest
{
	[TestClass]
	public class BankAccountServiceTest
	{

		[TestMethod]
		public void TestSummary_NoInfo()
		{
			OpenpayAPI api = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, false);
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

		[TestMethod]
		public void TestDetails_NoInfo()
		{
			OpenpayAPI api = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, false);
			List<Transaction> list = api.OpenpayFeesService.Details(2012, 03, "charged", null);
			Assert.AreEqual(0, list.Count);
		}

		[TestMethod]
		public void TestDetails_Pagination_NoInfo()
		{
			OpenpayAPI api = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID, false);
			PaginationParams pagination = new PaginationParams();
			pagination.Limit = 5;
			pagination.Offset = 5;
			List<Transaction> list = api.OpenpayFeesService.Details(2012, 03, "charged", pagination);
			Assert.AreEqual(0, list.Count);
		}

	}
}
