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
	public class WebhooksTest
	{

        [Test()]
        public void TestWebhooks_Create_Get_Verify_Get_List_Delete()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
			Webhook webhook = new Webhook();
			webhook.Url = "http://requestb.in/pmcmyopm";
			webhook.AddEventType("charge.refunded");
			webhook.AddEventType("charge.failed");

			Webhook webhookCreated = openpayAPI.WebhooksService.Create(webhook);
			Assert.IsNotNull(webhookCreated.Id);
			Assert.IsNotNull(webhookCreated.Status);
			Assert.AreEqual("verified", webhookCreated.Status);

			Webhook webhookGet = openpayAPI.WebhooksService.Get(webhookCreated.Id);
			Assert.IsNotNull(webhookGet.Id);
			Assert.IsNotNull(webhookGet.Status);
			Assert.AreEqual("verified", webhookGet.Status);
			Assert.AreEqual(2, webhookGet.EventTypes.Count);

            Assert.IsNotNull(webhookGet.Url);

			webhookGet = openpayAPI.WebhooksService.Get(webhookCreated.Id);
			Assert.IsNotNull(webhookGet.Id);
			Assert.IsNotNull(webhookGet.Status);
			Assert.AreEqual("verified", webhookGet.Status);
			Assert.AreEqual(2, webhookGet.EventTypes.Count);

			List<Webhook> webhooksList = openpayAPI.WebhooksService.List();
			Assert.AreEqual(2, webhooksList.Count);

			openpayAPI.WebhooksService.Delete(webhookGet.Id);
		}

	}
}

