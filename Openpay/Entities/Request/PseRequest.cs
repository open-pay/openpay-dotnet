using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
     [JsonObject(MemberSerialization.OptIn)]
    public class PseRequest : JsonObject
    {
        public PseRequest(){}

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { set; get; }

        [JsonProperty(PropertyName = "iva")]
        public String Iva { set; get; }

        [JsonProperty(PropertyName = "description")]
        public String Description { set; get; }

        [JsonProperty(PropertyName = "order_id", NullValueHandling=NullValueHandling.Ignore)]
        public String OrderId { set; get; }

        [JsonProperty(PropertyName = "device_session_id", NullValueHandling=NullValueHandling.Ignore)]
        public String DeviceSessionId { set; get; }

        [JsonProperty(PropertyName = "currency", NullValueHandling=NullValueHandling.Ignore)]
        public String Currency { set; get; }

        [JsonProperty(PropertyName = "metadata", NullValueHandling=NullValueHandling.Ignore)]
        public Dictionary<String, String> Metadata { set; get; }

        [JsonProperty(PropertyName = "customer", NullValueHandling=NullValueHandling.Ignore)]
        public Customer Customer { set; get; }

        [JsonProperty(PropertyName = "country")]
        public String Country { set; get; }

    }
}
