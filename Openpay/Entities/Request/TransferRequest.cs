using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TransferRequest : JsonObject
    {
        [JsonProperty(PropertyName = "customer_id")]
        public String CustomerId { set; get; }

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { set; get; }

        [JsonProperty(PropertyName = "description")]
        public String Description { set; get; }

		[JsonProperty(PropertyName = "order_id", NullValueHandling=NullValueHandling.Ignore)]
        public String OrderId { set; get; }


    }
}
