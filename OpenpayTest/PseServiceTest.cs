using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.PseRequest;
using System.Collections.Generic;

namespace OpenpayTest
{
    [TestClass]
    public class PseServiceTest
    {


        [Test()]
		public void TestPsePaymentByMerchant()
		{
            OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);

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

            Address address = new Address();
            address.Department = "Medellín";
            address.City = "Antioquia";
            address.Additional = "Avenida 18e bis #17-28 Apartamento 451";

            customer.Address = address;

            request.Customer = customer;

            Pse pse = openpayAPI.PseService.Create(request);
            Assert.IsNotNull(pse);
            Assert.IsNotNull(pse.Id);
            Assert.IsNotNull(">>> pse: " + pse.ToString());

        }
        
    }
}
