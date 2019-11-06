using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayNUnitTests
{
	[TestFixture()]
	public class SubscriptionTest
	{

		[Test()]
		public void TestCreateSubscriptionPlan()
		{
			Decimal amount = new Decimal(111.11);

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			Plan request = new Plan();
			request.Name = "Plan Mono Gold";
			request.Amount = amount;
			request.RepeatEvery = 1;
			request.RepeatUnit = "month";
			request.RetryTimes = 2;
			request.StatusAfterRetry = "cancelled";
			request.TrialDays = 30;

			request = openpayAPI.PlanService.Create(request);

			Assert.IsNotNull(request);
			Assert.IsNotNull(request.Id);
			Assert.IsNotNull(request.CreationDate);
			Assert.IsNotNull(request.Name);
			//Assert.AreEqual("Plan Mono Gold", request.Name);
			Assert.AreEqual("active", request.Status);

		}

		[Test()]
		public void TestCreateSubscribeClient()
		{
			string planId = "pnyiir7vy2e9ujsd25oo";
			string customerId = "a8tnslpnbcwnrxqavrkg";
			string cardId = "kepao7hxxluykjhxq2yq";
			DateTime trialEndDate = new DateTime(2017,10,21);

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			Subscription subscriptionRequest = new Subscription();
			subscriptionRequest.PlanId = planId;
			subscriptionRequest.TrialEndDate = trialEndDate;
			subscriptionRequest.CardId = cardId;

			subscriptionRequest = openpayAPI.SubscriptionService.Create(customerId, subscriptionRequest);

			Assert.IsNotNull(subscriptionRequest);
			Assert.IsNotNull(subscriptionRequest.Status);
			Assert.IsNotNull(subscriptionRequest.Transaction);

		}

		[Test()]
		public void TestCreateSubscribeClientWithCharge()
		{
			string planId = "pnyiir7vy2e9ujsd25oo";
			string customerId = "a8tnslpnbcwnrxqavrkg";
			string cardId = "kepao7hxxluykjhxq2yq";
			DateTime trialEndDate = new DateTime(2016, 10, 19);

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			Subscription subscriptionRequest = new Subscription();
			subscriptionRequest.PlanId = planId;
			subscriptionRequest.TrialEndDate = trialEndDate;
			subscriptionRequest.CardId = cardId;

			subscriptionRequest = openpayAPI.SubscriptionService.Create(customerId, subscriptionRequest);

			Assert.IsNotNull(subscriptionRequest);
			Assert.IsNotNull(subscriptionRequest.Status);
			Assert.IsNotNull(subscriptionRequest.Transaction);
		}

        /*
		[Test()]
        public void TestCreateAndUpdate()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
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
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);

            subscription.Card = card;
            subscription = openpayAPI.SubscriptionService.Update(customer_id, subscription);
            Assert.IsNotNull(subscription.Card);
            int cardLength = card.CardNumber.Length;
            Assert.AreEqual("510510XXXXXX5100", subscription.Card.CardNumber);

            Subscription subscriptionGet = openpayAPI.SubscriptionService.Get(customer_id, subscription.Id);
            Assert.AreEqual(subscription.TrialEndDate, subscriptionGet.TrialEndDate);
        }
        */
		
		[Test()]
        public void TestListSubscriptions()
        {
            string customerId = "a8tnslpnbcwnrxqavrkg";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            List<Subscription> subscriptions = openpayAPI.SubscriptionService.List(customerId);
            Assert.IsTrue(subscriptions.Count > 0);
        }
		
	}
}

