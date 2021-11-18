using NUnit.Framework;
using Openpay;
using Openpay.Entities;

namespace OpenpayNUnitTests.TestPeru
{
    [TestFixture()]
    public class TokenTests
    {
        OpenpayAPI openpayAPI = new OpenpayAPI(Constants.NEW_API_KEY, Constants.NEW_MERCHANT_ID,"PE");

        [Test()]
        public void CreateToken()
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

            Token token = openpayAPI.TokenService.Create(tokenRequest);
            Assert.NotNull(token);
        }

        [Test()]
        public void GetToken()
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

            Token token = openpayAPI.TokenService.Create(tokenRequest);

            Token token_ = openpayAPI.TokenService.Get(token.Id);

            Assert.AreEqual(token.Id, token_.Id);
        }
    }
}