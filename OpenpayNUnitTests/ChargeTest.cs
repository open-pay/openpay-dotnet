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
	public class ChargeTest
	{

		[Test()]
		public void TestGetByOrderId()
		{

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

            /*
            // --- Create Charge
            Card card = openpayAPI.CardService.Create(GetCardInfo());

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(111);
            request.Currency = "COP";
            request.Iva = "17";
            request.OrderId = "orderColCop111";

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            Address address = new Address();
            address.Department = "Medellín";
            address.City = "Antioquia";
            address.Additional = "Avenida 17d bis #13-25 Apartamento 444";

            customer.Address = address;

            request.Customer = customer;
            request.DeviceSessionId = "myDevice123Net";
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Console.WriteLine(">>> charge status: " + charge.Status.ToString());
            Assert.AreEqual("completed", charge.Status);
            */

            // INI ------------------


            string orderId = "orderColCop111";

			SearchParams search = new SearchParams();
			search.OrderId = orderId;
			search.Status = TransactionStatus.COMPLETED;
			search.CreationGte = new DateTime(2019, 11, 1);
            search.CreationLte = new DateTime(2019, 11, 5);
			List<Charge> charges = openpayAPI.ChargeService.List(search);

			Console.WriteLine("charges: " + charges.ToArray());

			Assert.IsNotNull(charges);
			Assert.AreEqual(1, charges.Count);
            // FIN ------------------

        }

        [Test()]
		public void TestCardCharge()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
			Card card = openpayAPI.CardService.Create(GetCardInfo());

			ChargeRequest request = new ChargeRequest();
			request.Method = "card";
			request.SourceId = card.Id;
			request.Description = "Testing from .Net";
			request.Amount = new Decimal(111);
            request.Currency = "COP";
            request.Iva = "17";

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.Department = "Medellín";
            customerAddress.City = "Antioquia";
            customerAddress.Additional = "Avenida 17d bis #13-25 Apartamento 444";

            customer.CustomerAddress = customerAddress;

            request.Customer = customer;
            request.DeviceSessionId = "myDevice123Net";
            Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
            Console.WriteLine(">>> charge status: " + charge.Status.ToString());

            Assert.AreEqual("completed", charge.Status);

		}

        [Test()]
        public void TestCancel()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.Description = "Testing from .Net with redirect";
            request.Amount = new Decimal(111);
            request.Currency = "COP";
			request.Iva = "17";

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.Department = "Medellín";
            customerAddress.City = "Antioquia";
            customerAddress.Additional = "Avenida 17d bis #13-25 Apartamento 444";

            customer.CustomerAddress = customerAddress;

            request.Customer = customer;
            request.DeviceSessionId = "myDevice123Net";

            request.Confirm = "false";

            Random rnd = new Random();
            String orderId = rnd.Next(1, 999999999).ToString();
            request.OrderId = rnd.Next(1, 999999999).ToString();

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Console.WriteLine(">>> charge : " + charge.ToJson().ToString());

            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("charge_pending", charge.Status);
            Console.WriteLine(">>> charge status: " + charge.Status.ToString());

            Charge cancelledCharge = openpayAPI.ChargeService.CancelByMerchant(Constants.NEW_MERCHANT_ID, charge.Id, request);

            Console.WriteLine(">>> cancelled charge: " + cancelledCharge.ToJson().ToString());
            Console.WriteLine(">>> cancelled charge status: " + cancelledCharge.Status.ToString());

        }

        [Test()]
        public void TestMerchantChargeWithStore()
        {
            ChargeRequest request = new ChargeRequest();

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Test";
            customer.PhoneNumber = "1234567890";
            customer.Email = "noemail@openpay.mx";

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.Department = "Medellín";
            customerAddress.City = "Antioquia";
            customerAddress.Additional = "Avenida 17d bis #13-25 Apartamento 444";

            customer.CustomerAddress = customerAddress;

            request.Customer = customer;

            request.Method = "store";
            request.Description = "Testing from .Net [STORE]";
            request.Amount = new Decimal(1010);
            request.Currency = "COP";
			request.Iva = "17";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.AreEqual("in_progress", charge.Status);
        }

        [Test()]
		public void TestRefundCharge()
		{

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
			Card card = openpayAPI.CardService.Create(GetCardInfo2());

			SearchParams searh = new SearchParams();
			List<Customer> customers = openpayAPI.CustomerService.List(searh);
			Customer customer = customers[0];
			customer.ExternalId = null;

			ChargeRequest request = new ChargeRequest();
			request.Method = "card";
			request.SourceId = card.Id;
			request.Description = "Testing from .Net";
            request.Amount = 100;
			request.Currency = "COP";
            request.Iva = "19";
            request.Currency = "COP";
            request.DeviceSessionId = "sah2e76qfdqa72ef2e2q";
			request.Customer = customer;

			Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.AreEqual("completed", charge.Status);

			Decimal refundAmount = charge.Amount;
			string description = "reembolso desce .Net de " + refundAmount;

			Charge refund = openpayAPI.ChargeService.Refund(charge.Id, description, refundAmount);

			Assert.IsNotNull(refund);
			Assert.IsNotNull(refund.Id);
			Assert.IsNotNull(refund.CreationDate);
			Assert.AreEqual("completed", refund.Status);
		}

		[Test()]
		public void TestRedirectCharge()
		{

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			SearchParams search = new SearchParams();
			List<Customer> customers = openpayAPI.CustomerService.List(search);
			Customer customer = customers[0];
			customer.ExternalId = null;

			ChargeRequest request = new ChargeRequest();
			request.Method = "card";
			request.Description = "Testing redirect from .Net";
            request.Amount = new Decimal(10000);
            request.Currency = "COP";
			request.Iva = "17";

            request.DeviceSessionId = "sah2e76qfdqa72ef2e2q";
			request.Customer = customer;
			request.Confirm = "false";
			request.SendEmail = true;
			request.RedirectUrl = "http://www.openpay.mx/index.html";

			Charge charge = openpayAPI.ChargeService.Create(request);
			Assert.IsNotNull(charge);
			Assert.IsNotNull(charge.Id);
			Assert.IsNotNull(charge.CreationDate);
			Assert.AreEqual("charge_pending", charge.Status);
			Console.WriteLine("Url: "+ charge.PaymentMethod.Url);

		}


        public void TestChargeWithAffiliation()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
            Card card = openpayAPI.CardService.Create(GetCardInfo());

            ChargeRequest request = new ChargeRequest();
            request.Method = "card";
            request.SourceId = card.Id;
            request.Description = "Testing from .Net";
            request.Amount = new Decimal(215.00);
			request.Currency = "COP";
			request.Iva = "15";

            Affiliation affiliation = new Affiliation();
            affiliation.Name = "amex_3d";
            request.Affiliation = affiliation;

            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.IsNotNull(charge.CreationDate);
            Assert.AreEqual("completed", charge.Status);
        }

		public Card GetCardInfo()
		{
			Card card = new Card();
			card.CardNumber = "4242424242424242";
			card.HolderName = getRandomWordUpperCase(5) + " " + getRandomWordLowerCase(5);
            card.Cvv2 = getRandomNumberAsString(100, 999);
            card.ExpirationMonth = "0" + String.Concat(new Random().Next(1, 9));
            card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            return card;
		}

        public Card GetCardInfo2()
		{
			Card card = new Card();
			card.CardNumber = "4242424242424242";
            card.HolderName = getRandomWordUpperCase(5) + " " + getRandomWordLowerCase(5);
            card.Cvv2 = getRandomNumberAsString(100, 999);
            card.ExpirationMonth = "0" + String.Concat(new Random().Next(1, 9));
            card.ExpirationYear = DateTime.Now.AddYears(3).Year.ToString().Substring(2);
            return card;
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
                text = string.Concat(text, (char)rnd.Next('a', 'z'));
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
