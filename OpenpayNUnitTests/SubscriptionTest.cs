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
			Assert.IsNull(subscriptionRequest.Transaction);

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

	}
}

