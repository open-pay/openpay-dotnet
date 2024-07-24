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

		[Test()]
		public void TestFeeAndRefund()
		{
			string customerId = "ar2btmquidjhykdaztp6";
			Decimal amount = new Decimal(11);
			string description = "comisión de .Net de "+ amount;
			string refundDescription = "reembolso de comisión de .Net de "+ amount;

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, Constants.PublicIp);

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

		}

	}
}

