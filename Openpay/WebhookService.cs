/*
 * COPYRIGHT © 2014. OPENPAY.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Class: WebhookService.cs
 * 
 * Change control:
 * ---------------------------------------------------------------------------------------
 * Version | Date       | Name                                      | Description
 * ---------------------------------------------------------------------------------------
 *   1.0	2014-12-01	Marcos Coronado marcos.coronado@openpay.mx	 Creating Class.
 *
 */
using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
	/**
	 * <summary>
	 * Clase base que contiene las operaciones disponibles para la administracion de los webhooks
	 * </summary>
	 */
	public class WebhookService : OpenpayResourceService<Webhook, Webhook>
	{

		public WebhookService(string api_key, string merchant_id, Countries country, bool production = false)
			: base(api_key, merchant_id, country, production)
		{
			ResourceName = "webhooks";
		}

		internal WebhookService(OpenpayHttpClient opHttpClient)
			: base(opHttpClient)
		{
			ResourceName = "webhooks";
		}

		public Webhook Create(Webhook webhook)
		{
			return base.Create(null, webhook);
		}

		public void Verify(string webhook_id, string verification_code)
		{
			string url = GetEndPoint(null, webhook_id) + "/verify" + "/" + verification_code;
			this.httpClient.Post<Webhook>(url);
		}
		
		public Webhook Get(string webhook_id)
		{
			return base.Get(null, webhook_id);
		}

		public void Delete(string webhook_id)
		{
			base.Delete(null, webhook_id);
		}

		public List<Webhook> List()
		{
			return base.List(null, null);
		}

	}
}

