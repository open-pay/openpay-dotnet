using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class PlantServiceTest
    {

        string customer_id = "adyytoegxm6boiusecxm";

        [TestMethod]
        public void TestCreateGeDelete()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Plan plan = new Plan();
            plan.Name = "Tv";
            plan.Amount = 99.99m;
            plan.RepeatEvery = 1;
            plan.RepeatUnit = "month";
            plan.StatusAfterRetry = "unpaid";
            plan.TrialDays = 0;
            Plan planCreated = openpayAPI.PlanService.Create(plan);
            Assert.IsNotNull(planCreated.Id);
            Assert.IsNotNull(planCreated.CreationDate);
            Assert.AreEqual("active", planCreated.Status);

            Plan planGet = openpayAPI.PlanService.Get(planCreated.Id);
            Assert.AreEqual(planCreated.Name, planGet.Name);

            openpayAPI.PlanService.Delete(planCreated.Id);
        }


        [TestMethod]
        public void TestUpdatePlan()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Plan plan = openpayAPI.PlanService.Get("pxs6fx3asdaa7xg3ray4");
            Random rnd = new Random();
            string newName = plan.Name + rnd.Next(0, 10);
            plan.Name = newName;
            Plan plantUpdated = openpayAPI.PlanService.Update(plan);
            Assert.AreEqual(newName, plantUpdated.Name);
        }

        [TestMethod]
        public void TestListSubscriptions()
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
            card.CardNumber = "5243385358972033";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "15";

            Subscription subscription = new Subscription();
            subscription.PlanId = plan.Id;
            subscription.Card = card;
            subscription = openpayAPI.SubscriptionService.Create(customer_id, subscription);

            List<Subscription> subscriptions = openpayAPI.PlanService.Subscriptions(plan.Id);
            Assert.AreEqual(1, subscriptions.Count);

            openpayAPI.SubscriptionService.Delete(customer_id, subscription.Id);
            openpayAPI.PlanService.Delete(plan.Id);
        }

        [TestMethod]
        public void TestList()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            List<Plan> plans = openpayAPI.PlanService.List();
            Assert.IsTrue(plans.Count > 0);

        }
    }
}
