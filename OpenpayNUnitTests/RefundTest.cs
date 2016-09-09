
using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayNUnitTests
{
	[TestFixture()]
	public class RefundTest
	{

		[Test()]
		public void TestRefund()
		{
			string merchantId = "mexzhpxok3houd5lbvz1";
			string privateKey = "sk_440e7370f8f34ed592463a452d122a4c";

			string chargeId = "trqqoimnrykrexkepmoa";
			string description = "Devolución parcial de mono3 55 pesotes de 106";
			Decimal amount = new Decimal(56.00);

			OpenpayAPI openpayAPI = new OpenpayAPI(privateKey, merchantId);

			//Charge charge = openpayAPI.ChargeService.Refund(chargeId, description);
			Charge charge = openpayAPI.ChargeService.Refund(chargeId, description, amount);

			Console.WriteLine("refundId: " + charge.Id);

			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.AreEqual("completed", charge.Status);
		}

		[Test()]
		public void TestFeeRefund()
		{
			string merchantId = "mexzhpxok3houd5lbvz1";
			string privateKey = "sk_440e7370f8f34ed592463a452d122a4c";

			string feeId = "triv4iqgmvikwvhb6ary";
			string description = "Devolución de comisión mono 12 pesotes";

			OpenpayAPI openpayAPI = new OpenpayAPI(privateKey, merchantId);

			Fee fee = openpayAPI.FeeService.Refund(feeId, description);
			Console.WriteLine("fee: " + fee);
			Assert.IsNotNull(fee);
			Assert.IsNotNull(fee.Id);
			Assert.IsNotNull(fee.CreationDate);
			Assert.AreEqual("completed", fee.Status);
		}
	}
}

