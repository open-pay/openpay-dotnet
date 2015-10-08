using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

	public class OpenpayFeesSummary : JsonObject
	{
		[JsonProperty(PropertyName = "charged")]
		public Decimal Charged { get; set; }

		[JsonProperty(PropertyName = "charged_tax")]
		public Decimal ChargedTax { get; set; }

		[JsonProperty(PropertyName = "charged_adjustments")]
		public Decimal ChargedAdjustments { get; set; }

		[JsonProperty(PropertyName = "charged_adjustments_tax")]
		public Decimal ChargedAdjustmentsTax { get; set; }

		[JsonProperty(PropertyName = "refunded")]
		public Decimal Refunded { get; set; }

		[JsonProperty(PropertyName = "refunded_tax")]
		public Decimal RefundedTax { get; set; }

		[JsonProperty(PropertyName = "refunded_adjustments")]
		public Decimal RefundedAdjustments { get; set; }

		[JsonProperty(PropertyName = "refunded_adjustments_tax")]
		public Decimal RefundedAdjustmentsTax { get; set; }

		[JsonProperty(PropertyName = "total")]
		public Decimal Total { get; set; }

	}
}

