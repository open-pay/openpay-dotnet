using NUnit.Framework;
using Openpay.Utils;

namespace OpenpayNUnitTests
{
	[TestFixture ()]
	public class UrlUtilsTest
	{
		[Test()]
		public void encodeSquare()
		{
			UrlUtils urlUtils = new UrlUtils();
			string url = "https://sandbox-api.openpay.mx/v1/mwfxtxcoom7dh47pcds1/customers?limit=3&offset=0&amount[gte]=1.00";
			string urlSpec = "https://sandbox-api.openpay.mx/v1/mwfxtxcoom7dh47pcds1/customers?limit=3&offset=0&amount%5Bgte%5D=1.00";
			string encodeUrlResult = urlUtils.ScapeSquareBrackets(url);
			Assert.AreEqual(urlSpec,encodeUrlResult);
		}
        
	}
}

