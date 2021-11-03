using System;
using System.Collections.Generic;
using NUnit.Framework;
using Openpay;
using Openpay.Entities;

namespace OpenpayNUnitTests.TestPeru
{
    [TestFixture()]
    public class WebhookTests
    {
        OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID,"PE");

        [Test()]
        public void Create()
        {
            Webhook newWebhook = GetWebhook();
            Webhook addedWebhook = openpayAPI.WebhooksService.Create(newWebhook);
            Assert.NotNull(addedWebhook);
        }

        [Test()]
        public void Get()
        {
            Webhook newWebhook = GetWebhook();
            Webhook addedWebhook = openpayAPI.WebhooksService.Create(newWebhook);
            Webhook webhook = openpayAPI.WebhooksService.Get(addedWebhook.Id);
            Assert.AreEqual(addedWebhook.Id, webhook.Id);
        }

        [Test()]
        public void Delete()
        {
            Webhook newWebhook = GetWebhook();
            Webhook addedWebhook = openpayAPI.WebhooksService.Create(newWebhook);
            openpayAPI.WebhooksService.Delete(addedWebhook.Id);
            Assert.Throws<OpenpayException>(delegate
            {
                openpayAPI.WebhooksService.Delete(addedWebhook.Id);
            });
        }

        [Test()]
        public void List()
        {
            List<Webhook> webhooks = openpayAPI.WebhooksService.List();
            Assert.NotNull(webhooks);
        }

        private Webhook GetWebhook()
        {
            Webhook newWebhook = new Webhook();
            newWebhook.Url = "https://webhook.site/7dcd7575-d0f0-4e78-b8e1-f821add69c2c";
            newWebhook.User = "juanito";
            newWebhook.Password = "juanitoPass";
            List<String> events = new List<string>
            {
                "charge.refunded",
                "charge.failed",
                "charge.cancelled",
                "charge.created",
                "chargeback.accepted"
            };
            newWebhook.EventTypes = events;

            return newWebhook;
        }
    }
}