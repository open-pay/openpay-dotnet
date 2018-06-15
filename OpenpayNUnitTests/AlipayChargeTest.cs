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
	public class AlipayChargeTest
	{

		[Test()]
		public void TestAlipayRedirectCharge()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			SearchParams searh = new SearchParams();
			List<Customer> customers = openpayAPI.CustomerService.List(searh);
			Customer customer = customers[0];
			customer.ExternalId = null;

			ChargeRequest request = new ChargeRequest();
			request.Method = "alipay";
			request.Description = "Testing Alipay redirect from .Net";
			request.Amount = new Decimal(1110.00);
			request.Customer = customer;
			request.RedirectUrl = "http://www.openpay.mx/index.html";

			Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.IsNotNull(charge.DueDate);
			Assert.AreEqual("charge_pending", charge.Status);
			Console.WriteLine("Url: "+ charge.PaymentMethod.Url);
			Console.WriteLine("Due Date: "+ charge.DueDate);
		}

	}
}

