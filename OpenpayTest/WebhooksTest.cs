using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Openpay;
using Openpay.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace OpenpayTest
{
	[TestClass]
	public class WebhooksTest
	{
		[TestMethod]
		public void TestWebhooks_Create_Get_Verify_Get_List_Delete()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			Webhook webhook = new Webhook();
			webhook.Url = "http://requestb.in/qozy7dqp";
			webhook.AddEventType("charge.refunded");
			webhook.AddEventType("charge.failed");

			Webhook webhookCreated = openpayAPI.WebhooksService.Create(webhook);
			Assert.IsNotNull(webhookCreated.Id);
			Assert.IsNotNull(webhookCreated.Status);
			Assert.AreEqual("unverified", webhookCreated.Status);

			Webhook webhookGet = openpayAPI.WebhooksService.Get(webhookCreated.Id);
			Assert.IsNotNull(webhookGet.Id);
			Assert.IsNotNull(webhookGet.Status);
			Assert.AreEqual("unverified", webhookGet.Status);
			Assert.AreEqual(2, webhookGet.EventTypes.Count);

			openpayAPI.WebhooksService.Verify(webhookGet.Id, webhookGet.Url);

			webhookGet = openpayAPI.WebhooksService.Get(webhookCreated.Id);
			Assert.IsNotNull(webhookGet.Id);
			Assert.IsNotNull(webhookGet.Status);
			Assert.AreEqual("verified", webhookGet.Status);
			Assert.AreEqual(2, webhookGet.EventTypes.Count);

			List<webhook> webhooksList = openpayAPI.WebhooksService.List(webhookCreated.Id);
			Assert.AreEqual(1, webhooksList.Count);

			openpayAPI.WebhooksService.Delete(webhookGet.Id);
		}

		private string GetVerificationCode(string url_webhook)
		{
			string url = url_webhook + "?inspect";

			WebRequest req = (WebRequest)WebRequest.Create(url);
			req.Method = "POST";
			if (req is HttpWebRequest)
			{
				((HttpWebRequest)req).UserAgent = user_agent;
			}
			//req.Credentials = credential;
			req.PreAuthenticate = false;
			req.Timeout = 60 * 1000;
			req.ContentType = "application/json";

			// Obteniendo respuesta
			string result = null;

			try
			{
				using (WebResponse resp = (WebResponse)req.GetResponse())
				{
					result = GetResponseAsString(resp);
				}
			}
			catch (WebException wexc)
			{
				if (wexc.Response != null)
				{
					string json_error = GetResponseAsString(wexc.Response);
					HttpStatusCode status_code = HttpStatusCode.BadRequest;
					HttpWebResponse resp = wexc.Response as HttpWebResponse;
					if (resp != null)
						status_code = resp.StatusCode;

					if ((int)status_code <= 500)
						throw OpenpayException.GetFromJSON(status_code, json_error);
				}
				throw;
			}
			return result.Substring (result.IndexOf ("verification_code") + 28, 8);
		}

		private string GetResponseAsString(WebResponse response)
		{
			using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
			{
				return sr.ReadToEnd();
			}
		}
	}
}

