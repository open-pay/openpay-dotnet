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
            card.CardNumber = "4111111111111111";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "15";

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
            string customer_id = "adyytoegxm6boiusecxm";
            Card card = new Card();
            card.CardNumber = "4111111111111111";
            card.HolderName = "Juanito Pérez Nuñez";
            card.Cvv2 = "123";
            card.ExpirationMonth = "01";
            card.ExpirationYear = "15";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

            card = openpayAPI.CardService.Create(customer_id, card);
            Assert.IsNotNull(card.Id);
            openpayAPI.CardService.Delete(customer_id, card.Id);
        }

        [TestMethod]
        public void TestCard_Get()
        {
            string customer_id = "adyytoegxm6boiusecxm";
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
                Card card = openpayAPI.CardService.Get(customer_id, card_id);
                Assert.AreEqual(card_id, card.Id);

                List<Card> cards = openpayAPI.CardService.List(customer_id);
                Assert.IsNotNull(cards);
                Assert.AreEqual(1, cards.Count);
            }
        }
    }
}
