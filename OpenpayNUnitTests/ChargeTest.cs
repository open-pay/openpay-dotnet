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
	public class ChargeTest
	{

		[Test()]
		public void TestGetByOrderId()
		{
			string orderId = "mono3-scoti-oid-00006";

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			SearchParams search = new SearchParams();
			search.OrderId = orderId;
			List<Charge> charges = openpayAPI.ChargeService.List(search);

			Console.WriteLine("charges: " + charges.ToArray());

			Assert.IsNotNull(charges);
			Assert.AreEqual(1, charges.Count);
		}

		[Test()]
		public void TestCharge()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			Card card = openpayAPI.CardService.Create(GetCardInfo());

			ChargeRequest request = new ChargeRequest();
			request.Method = "card";
			request.SourceId = card.Id;
			request.Description = "Testing from .Net";
			request.Amount = new Decimal(111.00);


			Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.AreEqual("completed", charge.Status);
		}

		[Test()]
		public void TestRefundCharge()
		{
			string customerExternaiId = "monos003_customer001";

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
			Card card = openpayAPI.CardService.Create(GetScotiaCardInfo());

			SearchParams searh = new SearchParams();
			searh.ExternalId = customerExternaiId;
			List<Customer> customers = openpayAPI.CustomerService.List(searh);
			Customer customer = customers[0];
			customer.ExternalId = null;

			ChargeRequest request = new ChargeRequest();
			request.Method = "card";
			request.SourceId = card.Id;
			request.Description = "Testing from .Net";
			request.Amount = new Decimal(111.00);
			request.DeviceSessionId = "sah2e76qfdqa72ef2e2q";
			request.Customer = customer;

			Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.AreEqual("completed", charge.Status);

			Decimal partialAmount = charge.Amount/2;
			string description = "reembolso parcial desce .Net de " + partialAmount;

			Charge refund = openpayAPI.ChargeService.Refund(charge.Id, description, partialAmount);

			Assert.IsNotNull(refund);
			Assert.IsNotNull(refund.Id);
			Assert.IsNotNull(refund.CreationDate);
			Assert.AreEqual("completed", refund.Status);
		}

		[Test()]
		public void TestRedirectCharge()
		{
			string customerExternaiId = "monos003_customer001";

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			SearchParams searh = new SearchParams();
			searh.ExternalId = customerExternaiId;
			List<Customer> customers = openpayAPI.CustomerService.List(searh);
			Customer customer = customers[0];
			customer.ExternalId = null;

			ChargeRequest request = new ChargeRequest();
			request.Method = "card";
			request.Description = "Testing redirect from .Net";
			request.Amount = new Decimal(111.00);
			request.DeviceSessionId = "sah2e76qfdqa72ef2e2q";
			request.Customer = customer;
			request.Confirm = false;
			request.SendEmail = true;
			request.RedirectUrl = "http://www.openpay.mx/index.html";

			Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.AreEqual("charge_pending", charge.Status);
			Console.WriteLine("Url: "+ charge.PaymentMethod.Url);

		}

		[Test()]
		public void TestPointsBalance()
		{
			//string customerExternaiId = "monos003_customer001";
			String customer_id = "asda4znfoxhvpgcsui3q";
			String card_id = "keqctdqbro2b7jtcnz7d";

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
			//Card card = openpayAPI.CardService.Create(GetScotiaCardInfo());

			PointsBalance pointsBalance = openpayAPI.CardService.Points(customer_id,card_id);

			Assert.IsNotNull(pointsBalance);
			Assert.AreEqual(PointsType.BANCOMER, pointsBalance.PointsTypeEnum);
			Assert.AreEqual(new Decimal(33.750), pointsBalance.RemainingMxn);
			Assert.AreEqual(new BigInteger(450), pointsBalance.RemainingPoints);

			Console.WriteLine("pointsBalance:[pointsTypeEnum:" + pointsBalance.PointsTypeEnum + "pointsBalance:[pointsType:" + pointsBalance.PointsType + ", remaining Mx:" + pointsBalance.RemainingMxn + ", remainingPoints:" + pointsBalance.RemainingPoints + "]");

		}

		[Test ()]
		public void TestSantanderPoints ()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			Card card = openpayAPI.CardService.Create (GetCardInfo ());

			ChargeRequest request = new ChargeRequest();
			request.Method = "card";
			request.SourceId = card.Id;
			request.Description = "Testing from .Net";
			request.Amount = new Decimal(215.00);
			request.UseCardPoints = UseCardPointsType.MIXED.ToString();

			Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.AreEqual("completed", charge.Status);
		}

		public Card GetCardInfo()
		{
			Card card = new Card();
			card.CardNumber = "5470464956333056";
			card.HolderName = "Juanito Pérez Nuñez";
			card.Cvv2 = "132";
			card.ExpirationMonth = "12";
			card.ExpirationYear = "20";
			return card;
		}

		public Card GetScotiaCardInfo()
		{
			Card card = new Card();
			card.CardNumber = "5105105105105100";
			card.HolderName = "Aquiles Salto Ramon";
			card.Cvv2 = "111";
			card.ExpirationMonth = "11";
			card.ExpirationYear = "21";
			return card;
		}

	}
}

