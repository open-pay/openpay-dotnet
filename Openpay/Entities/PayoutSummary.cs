using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
	public class PayoutSummary : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "in")]
        public Decimal In { get; set; }

		[JsonProperty(PropertyName = "out")]
		public Decimal Out { get; set; }

		[JsonProperty(PropertyName = "charged_adjustments")]
		public Decimal ChargedAdjustments { get; set; }

		[JsonProperty(PropertyName = "refunded_adjustments")]
		public Decimal RefundedAdjustments { get; set; }

    }
}
