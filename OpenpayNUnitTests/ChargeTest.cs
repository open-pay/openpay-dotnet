using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayNUnitTests
{
	[TestFixture ()]
	public class ChargeTest
	{

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

	}
}

