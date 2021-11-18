using System.Collections.Generic;
using NUnit.Framework;
using Openpay;
using Openpay.Entities;

namespace OpenpayNUnitTests.TestPeru
{
    [TestFixture()]
    public class CardsTests
    {
        OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID,"PE");

        [Test()]
        public void Create()
        {
            Card card = new Card();
            card.HolderName = "Juan Perez";
            card.CardNumber = "4111111111111111";
            card.Cvv2 = "110";
            card.ExpirationMonth = "12";
            card.ExpirationYear = "21";
            Card addedCard = openpayAPI.CardService.Create(card);
            Assert.NotNull(addedCard);
        }
        
        [Test()]
        public void CreateWithCustomer()
        {
            Customer customer = openpayAPI.CustomerService.List()[0];
            Card card = new Card();
            card.HolderName = "Juan Perez";
            card.CardNumber = "4111111111111111";
            card.Cvv2 = "110";
            card.ExpirationMonth = "12";
            card.ExpirationYear = "21";
            Card addedCard = openpayAPI.CardService.Create(customer.Id, card);
            Assert.NotNull(addedCard);
        }

        [Test()]
        public void CreateWithToken()
        {
            Card card = new Card();
            Token token = GetToken();
            card.DeviceSessionId = token.Id;
            card.TokenId = token.Id;
            Card addedCard = openpayAPI.CardService.Create(card);
            Assert.NotNull(addedCard);
        }

        [Test()]
        public void Get()
        {
            Card card = new Card();
            Token token = GetToken();
            card.DeviceSessionId = token.Id;
            card.TokenId = token.Id;
            Card addedCard = openpayAPI.CardService.Create(card);
            Card card_ = openpayAPI.CardService.Get(addedCard.Id);
            Assert.AreEqual(addedCard.Id, card_.Id);
        }

        [Test()]
        public void Delete()
        {
            Card card = new Card();
            Token token = GetToken();
            card.DeviceSessionId = token.Id;
            card.TokenId = token.Id;
            Card addedCard = openpayAPI.CardService.Create(card);
            openpayAPI.CardService.Delete(addedCard.Id);
            Assert.Throws<OpenpayException>(delegate
            {
                openpayAPI.CardService.Delete(addedCard.Id);
            });
        }

        [Test()]
        public void List()
        {
            List<Card> cards = openpayAPI.CardService.List();
            Assert.NotNull(cards);
        }

        private Token GetToken()
        {
            {
                TokenRequest tokenRequest = new TokenRequest();
                tokenRequest.CardNumber = "4111111111111111";
                tokenRequest.HolderName = "Juan Perez Ramirez";
                tokenRequest.ExpirationYear = "21";
                tokenRequest.ExpirationMonth = "12";
                tokenRequest.Cvv2 = "110";
                Address address = new Address();
                address.City = "Lima";
                address.CountryCode = "PE";
                address.PostalCode = "110511";
                address.Line1 = "Av 5 de Febrero";
                address.Line2 = "Roble 207";
                address.Line3 = "col carrillo";
                address.State = "Lima";
                tokenRequest.Address = address;

                return openpayAPI.TokenService.Create(tokenRequest);
            }
        }
    }
}