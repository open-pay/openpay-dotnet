using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayNUnitTests
{
	[TestFixture ()]
	public class CreateCheckout
	{

		[Test()]
		public void TestAlipayRedirectCharge()
		{
			OpenpayAPI openpayApi = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID, "PE");

			SearchParams search = new SearchParams();
			List<Customer> customers = openpayApi.CustomerService.List(search);
			Customer customer = customers[0];
			customer.ExternalId = null;
			customer.Balance = null;
			customer.CreationDate = null;
			customer.RequiresAccount = null;
			customer.Id = null;
			customer.PhoneNumber = "7711111111";

			CheckoutRequest request = new CheckoutRequest();
			string oid = getOrderId();
			request.Amount = 250;
			request.Description = "Cargo cobro con link";
			request.OrderId = oid;
			request.Currency = "PEN";
			request.RedirectUrl = "https://misitioempresa.pe";
			request.SendEmail = false;
			request.Customer = customer;
			
			Checkout checkout = openpayApi.CheckoutService.Create(request);
			Assert.IsNotNull(checkout);
			Assert.AreEqual(oid, checkout.OrderId);
		}

		private string getOrderId()
		{
			Random rnd = new Random();
			return "oid-" + rnd.Next(11111, 1000000);
		}
	}
}

