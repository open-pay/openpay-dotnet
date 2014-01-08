using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class RefundRequest : OpenpayObject
    {
        [JsonProperty(PropertyName = "description")]
        public String Description { set; get; }

        [JsonProperty(PropertyName = "order_id")]
        public String OrderId { set; get; }
    }
}
