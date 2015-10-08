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
 * Class: Webhook.cs
 * 
 * Change control:
 * ---------------------------------------------------------------------------------------
 * Version | Date       | Name                                      | Description
 * ---------------------------------------------------------------------------------------
 *   1.0	2014-12-01	Marcos Coronado marcos.coronado@openpay.mx	 Creating Class.
 *
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

	/**
	 * <summary>
	 * Clase utilizada como contenedor de los parametros para la creacion de un webhook
	 * </summary>
	 */
	public class Webhook : OpenpayResourceObject
	{
		[JsonProperty(PropertyName = "url")]
		public String Url { get; set;}

		[JsonProperty(PropertyName = "user", NullValueHandling=NullValueHandling.Ignore)]
		public String User { get; set;}

		[JsonProperty(PropertyName = "password", NullValueHandling=NullValueHandling.Ignore)]
		public String Password { get; set;}

		[JsonProperty(PropertyName = "event_types", NullValueHandling=NullValueHandling.Ignore)]
		public List<String> EventTypes { get; set;}

		[JsonProperty(PropertyName = "status", NullValueHandling=NullValueHandling.Ignore)]
		public String Status { get; set;}

		public void AddEventType(String eventType) {
			if (this.EventTypes == null) {
				this.EventTypes = new List<string>();
			}
			this.EventTypes.Add(eventType);
		}
	}
}

