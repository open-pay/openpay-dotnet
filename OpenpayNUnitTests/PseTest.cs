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
	public class PseTest
	{

        [Test()]
        public void TestPsePaymentWithNewCustomer()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

            PseRequest request = new PseRequest();
            request.Country = "COL";
            request.Description = "Testing PSE from .Net";
            request.Amount = 10000;
            request.Iva = "190";
            request.Currency = "COP";
            Random rnd = new Random();
            String orderId = rnd.Next(1, 999999999).ToString();
            request.OrderId = DateTime.Now.ToString("MM/dd/yyyyHHmmss") + orderId;

            Customer customer = new Customer();
            customer.Name = "Openpay";
            customer.LastName = "Pay Test";
            customer.PhoneNumber = "1234567892";
            customer.Email = "noemailfortest@openpay.mx";

            CustomerAddress customerAddress = new CustomerAddress();
            customerAddress.Department = "Medellín";
            customerAddress.City = "Antioquia";
            customerAddress.Additional = "Avenida 18e bis #17-28 Apartamento 451";

            customer.CustomerAddress = customerAddress;

            request.Customer = customer;

            Pse pse = openpayAPI.PseService.Create(request);
            Assert.IsNotNull(pse);
            Assert.IsNotNull(pse.RedirectUrl);
            Console.WriteLine(">>> pse: " + pse.ToJson().ToString());

        }

        [Test()]
        public void TestPsePaymentWithCustomerId()
        {
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID);

            // Id Customer
            SearchParams search = new SearchParams();
            List<Customer> customers = openpayAPI.CustomerService.List(search);
            Customer existentCustomer = customers[0];

            // Creating Pse Payment
            PseRequest request = new PseRequest();
            request.Country = "COL";
            request.Description = "Testing PSE from .Net";
            request.Amount = 10000;
            request.Iva = "190";
            request.Currency = "COP";
            Random rnd = new Random();
            String orderId = rnd.Next(1, 999999999).ToString();
            request.OrderId = DateTime.Now.ToString("MM/dd/yyyyHHmmss") + orderId;

            Pse pse = openpayAPI.PseService.Create(existentCustomer.Id, request);
            Assert.IsNotNull(pse);
            Assert.IsNotNull(pse.RedirectUrl);
            Console.WriteLine(">>> pse: " + pse.ToJson().ToString());

        }

    }
}
