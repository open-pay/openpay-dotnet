using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class SubscriptionServiceTest
    {

        string customer_id = "adyytoegxm6boiusecxm";


        [TestMethod]
        public void TestCreateSubscription()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Plan plan = new Plan();
            plan.Name = "Tv";
            plan.Amount = 89.99m;
            plan.RepeatEvery = 1;
            plan.RepeatUnit = "month";
            plan.StatusAfterRetry = "unpaid";
            plan.TrialDays = 0;
            plan = openpayAPI.PlanService.Create(plan);

            Card card = new Card();
            card.CardNumber = "4242424242424242";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "17";

            Subscription subscription = new Subscription();
            subscription.PlanId = plan.Id;
            subscription.Card = card;
            subscription = openpayAPI.SubscriptionService.Create(customer_id, subscription);
            Assert.IsNotNull(subscription.Id);
            Assert.IsNotNull(subscription.CreationDate);
            Assert.AreEqual(false, subscription.CancelAtPeriodEnd);
            Assert.IsNotNull(subscription.ChargeDate);
            Assert.AreEqual(1, subscription.CurrentPeriod);
            Assert.IsNotNull(subscription.PeriodEndDate);
            //Assert.IsNull(subscription.TrialEndDate);
            Assert.IsNotNull(subscription.PlanId);
            Assert.IsNotNull(subscription.Status);
            Assert.AreEqual(customer_id, subscription.CustomerId);
            Assert.IsNotNull(subscription.PlanId);
            Assert.IsNotNull(subscription.Card);

            openpayAPI.SubscriptionService.Delete(customer_id, subscription.Id);
            openpayAPI.PlanService.Delete(plan.Id);
        }

        [TestMethod]
        public void TestCreateAndUpdate()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            string plan_id = "pxs6fx3asdaa7xg3ray4";
            Subscription subscription = new Subscription();
            subscription.PlanId = plan_id;
            subscription.CardId = "kwkoqpg6fcvfse8k8mg2";
            subscription = openpayAPI.SubscriptionService.Create(customer_id, subscription);
            Assert.IsNotNull(subscription.Card);

            Card card = new Card();
            card.CardNumber = "5105105105105100";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "17";

            subscription.Card = card;
            subscription = openpayAPI.SubscriptionService.Update(customer_id, subscription);
            Assert.IsNotNull(subscription.Card);
            int cardLength = card.CardNumber.Length;
            Assert.AreEqual("510510XXXXXX5100", subscription.Card.CardNumber);

            Subscription subscriptionGet = openpayAPI.SubscriptionService.Get(customer_id, subscription.Id);
            Assert.AreEqual(subscription.TrialEndDate, subscriptionGet.TrialEndDate);
        }

        [TestMethod]
        public void TestListSubscriptions()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            List<Subscription> subscriptions = openpayAPI.SubscriptionService.List(customer_id);
            Assert.IsTrue(subscriptions.Count > 0);
        }
    }
}
