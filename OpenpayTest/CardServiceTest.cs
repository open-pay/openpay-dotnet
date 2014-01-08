using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class CardServiceTest
    {
        [TestMethod]
        public void TestCard_CreateAsMerchant()
        {
            Card card = new Card();
            card.CardNumber = "5243385358972033";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "14";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
           
            card = openpayAPI.CardService.Create(card);
            Assert.IsNotNull(card.Id);
            Assert.IsNotNull(card.CreationDate);
            Assert.IsNull(card.Cvv2);
            openpayAPI.CardService.Delete(card.Id);
        }

        [TestMethod]
        public void TestCard_CreateAsCustomer()
        {
            Card card = new Card();
            card.CardNumber = "5243385358972033";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "14";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            card = openpayAPI.CardService.Create(card, "adyytoegxm6boiusecxm");
            Assert.IsNotNull(card.Id);
            openpayAPI.CardService.Delete(card.Id, "adyytoegxm6boiusecxm");
        }

        [TestMethod]
        public void TestCard_Get()
        {
            string card_id = "kwkoqpg6fcvfse8k8mg2";
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            try
            {
                openpayAPI.CardService.Get(card_id);
                Assert.Fail("La tarjeta no deberia existir.");
            }
            catch (OpenpayException e)
            {
                Assert.AreEqual(1005, e.ErrorCode);
                Card card = openpayAPI.CardService.Get(card_id, "adyytoegxm6boiusecxm");
                Assert.AreEqual(card_id, card.Id);

                List<Card> cards = openpayAPI.CardService.List("adyytoegxm6boiusecxm");
                Assert.IsNotNull(cards);
                Assert.AreEqual(1, cards.Count);
            }
        }
    }
}
