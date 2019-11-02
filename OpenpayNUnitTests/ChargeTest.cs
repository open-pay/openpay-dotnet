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
			string orderId = "mono3-scoti-oid-00006";

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

			SearchParams search = new SearchParams();
			search.OrderId = orderId;
			search.Status = TransactionStatus.REFUNDED;
			search.CreationGte = new DateTime(2016, 9, 7);
            search.CreationLte = new DateTime(2016, 10, 1);
			List<Charge> charges = openpayAPI.ChargeService.List(search);

			Console.WriteLine("charges: " + charges.ToArray());

			Assert.IsNotNull(charges);
			Assert.AreEqual(1, charges.Count);
		}

		[Test()]
		public void TestCardCharge()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
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

		}

        [Test()]
        public void TestCancel()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

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

            Address address = new Address();
            address.Department = "Medellín";
            address.City = "Antioquia";
            address.Additional = "Avenida 17d bis #13-25 Apartamento 444";

            customer.Address = address;

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

            Charge cancelledCharge = openpayAPI.ChargeService.CancelByMerchant(Constants.MERCHANT_ID, charge.Id, request);

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

            Address address = new Address();
            address.Department = "Medellín";
            address.City = "Antioquia";
            address.Additional = "Avenida 17d bis #13-25 Apartamento 444";

            customer.Address = address;

            request.Customer = customer;

            request.Method = "store";
            request.Description = "Testing from .Net [STORE]";
            request.Amount = new Decimal(1010);
            request.Currency = "COP";
			request.Iva = "17";

            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
            Charge charge = openpayAPI.ChargeService.Create(request);
            Assert.IsNotNull(charge);
            Assert.IsNotNull(charge.Id);
            Assert.AreEqual("in_progress", charge.Status);
        }

        [Test()]
		public void TestRefundCharge()
		{

			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);
			Card card = openpayAPI.CardService.Create(GetScotiaCardInfo());

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
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
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
			card.CardNumber = "5555555555554444";
			card.HolderName = "Juanito Pérez Nuñez";
			card.Cvv2 = "132";
			card.ExpirationMonth = "12";
			card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            return card;
		}

        public Card GetScotiaCardInfo()
		{
			Card card = new Card();
			card.CardNumber = "5105105105105100";
			card.HolderName = "Aquiles Salto Ramon";
			card.Cvv2 = "123";
			card.ExpirationMonth = "12";
			card.ExpirationYear = DateTime.Now.AddYears(2).Year.ToString().Substring(2);
            return card;
		}

	}
}
