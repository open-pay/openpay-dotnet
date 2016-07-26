using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities
{
	public class DeferralPayments : JsonObject
    {
		public DeferralPayments(int Payments)
		{ 
			this.Payments = Payments;
		}

		[JsonProperty(PropertyName = "payments")]
		public int Payments { get; set; }
 
    }
}
