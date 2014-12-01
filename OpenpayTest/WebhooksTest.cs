using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using System.Collections.Generic;

namespace OpenpayTest
{
	[TestClass]
	public class WebhooksTest
	{
		[TestMethod]
		public void TestCreateGetDelete()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			Webhook webhook = new Webhook();
			webhook.Url = "http://requestb.in/qozy7dqp";
			webhook.AddEventType("charge.refunded");
			webhook.AddEventType("charge.failed");

			Webhook webhookCreated = openpayAPI.WebhooksService.Create(webhook);
			Assert.IsNotNull(webhookCreated.Id);
			Assert.IsNotNull(webhookCreated.Status);
			Assert.AreEqual("unverified", webhookCreated.Status);

			Webhook webhookGet = openpayAPI.WebhooksService.Get(webhookCreated.Id);
			Assert.IsNotNull(webhookGet.Id);
			Assert.IsNotNull(webhookGet.Status);
			Assert.AreEqual("unverified", webhookGet.Status);
			Assert.AreEqual(2, webhookGet.EventTypes.Count);

			openpayAPI.WebhooksService.Delete(webhookGet.Id);
		}
	}
}

