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
    public class CardTest
    {
        [Test()]
        public void TestCard_CreateAsMerchant()
        {
            Card card = new Card();
            card.CardNumber = "4242424242424242";
            card.HolderName = getRandomWordUpperCase(5) + " " + getRandomWordLowerCase(5);
            card.Cvv2 = getRandomNumberAsString(100, 999);
            card.ExpirationMonth = "0" + String.Concat(new Random().Next(1, 9));
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            card.DeviceSessionId = "120938475692htbssd3";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

            card = openpayAPI.CardService.Create(card);
            Assert.IsNotNull(card.Id);
            Assert.IsNotNull(card.CreationDate);
            Assert.IsNull(card.Cvv2);
            openpayAPI.CardService.Delete(card.Id);
        }

        [Test()]
        public void TestCard_CreateAsCustomer()
        {
            // Create customer
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Customer customer = new Customer();
            customer.Name = "Net Client";
            customer.Email = "net@c.com";

            customer = openpayAPI.CustomerService.Create(customer);
            Assert.IsNotNull(customer);
            Assert.IsFalse(String.IsNullOrEmpty(customer.Id));

            // INI TEST ---------------------------------
            // Create as Customer
            string customer_id = customer.Id;

            Card card = new Card();
            card.CardNumber = "4111111111111111";
            card.HolderName = getRandomWordUpperCase(5) + " " + getRandomWordLowerCase(5);
            card.Cvv2 = getRandomNumberAsString(100,999);
            card.ExpirationMonth = "0" + String.Concat(new Random().Next(1, 9));
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            card.DeviceSessionId = "120938475692htbssd";

            card = openpayAPI.CardService.Create(customer_id, card);
            Assert.IsNotNull(card.Id);
            openpayAPI.CardService.Delete(customer_id, card.Id);

            // FIN TEST ---------------------------------

            // Delete customer
            openpayAPI.CustomerService.Delete(customer.Id);

        }

        [Test()]
        public void TestCard_Get()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

            // Create customer
            Customer customer = new Customer();
            customer.Name = "Net Testing";
            customer.LastName = "Perez";
            customer.Email = "net_email@comercio.co";
            customer.PhoneNumber = "5719383832";
            Address address = new Address();
            address.Department = "Medellín";
            address.City = "Antioquía";
            address.Additional = "Avenida 7f bis # 138-58 Apartamento 942";
            customer.Address = address;

            customer = openpayAPI.CustomerService.Create(customer);
            Assert.IsNotNull(customer);
            Assert.IsFalse(String.IsNullOrEmpty(customer.Id));

            // Create Card
            Card card = new Card();
            card.CardNumber = "4242424242424242";
            card.HolderName = getRandomWordUpperCase(5)+ " " + getRandomWordLowerCase(5);
            card.Cvv2 = getRandomNumberAsString(100, 999);
            card.ExpirationMonth = "0"+ String.Concat(new Random().Next(1, 9));
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            card.DeviceSessionId = "120938475692htbssd3";

            card = openpayAPI.CardService.Create(card);

            // INI TEST ---------------------------------
            string customer_id = customer.Id;
            string card_id = card.Id;
            Card cardRead = null;

            cardRead = openpayAPI.CardService.Get(card_id);
            Assert.AreEqual(cardRead.Id, card_id);

            // FIN TEST ---------------------------------

            // Delete Card
            openpayAPI.CardService.Delete(card.Id);

            // Delete customer
            openpayAPI.CustomerService.Delete(customer.Id);

        }

        private String getRandomNumberAsString(int min, int max)
        {
            return String.Concat(new Random().Next(100, 999));
        }

        private String getRandomWordLowerCase(int length)
        {
            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < length; i++)
            {
                text = string.Concat(text,(char)rnd.Next('a', 'z'));
            }
            return text.ToLower();
        }

        private String getRandomWordUpperCase(int length)
        {
            Random rnd = new Random();
            string text = "";
            for (int i = 0; i < length; i++)
            {
                text = string.Concat(text, (char)rnd.Next('a', 'z'));
            }
            return text.ToUpper();
        }

    }
}
