using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RefundRequest : JsonObject
    {
        [JsonProperty(PropertyName = "description")]
        public String Description { set; get; }

		[JsonProperty(PropertyName = "amount")]
		public Decimal? Amount { set; get; }

		[JsonProperty(PropertyName = "gateway", NullValueHandling = NullValueHandling.Ignore)]
		public Gateway Gateway { set; get; }

	}
}
