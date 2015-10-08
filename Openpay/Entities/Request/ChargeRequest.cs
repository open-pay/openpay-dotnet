using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
     [JsonObject(MemberSerialization.OptIn)]
    public class ChargeRequest : JsonObject
    {
         public ChargeRequest()
         { 
             Capture = true;
                                                                                                                                                                                                        
         }

         [JsonProperty(PropertyName = "method")]
         public String Method { set; get; }

		[JsonProperty(PropertyName = "source_id", NullValueHandling=NullValueHandling.Ignore)]
         public String SourceId { set; get; }

		[JsonProperty(PropertyName = "card", NullValueHandling=NullValueHandling.Ignore)]
         public Card Card { set; get; }

         [JsonProperty(PropertyName = "amount")]
         public Decimal Amount { set; get; }

         [JsonProperty(PropertyName = "description")]
         public String Description { set; get; }

		[JsonProperty(PropertyName = "order_id", NullValueHandling=NullValueHandling.Ignore)]
         public String OrderId { set; get; }

		[JsonProperty(PropertyName = "capture", NullValueHandling=NullValueHandling.Ignore)]
         public Boolean Capture { set; get; }

		[JsonProperty(PropertyName = "device_session_id", NullValueHandling=NullValueHandling.Ignore)]
		 public String DeviceSessionId { set; get; }

		[JsonProperty(PropertyName = "currency", NullValueHandling=NullValueHandling.Ignore)]
		public String Currency { set; get; }

        [JsonProperty(PropertyName = "due_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? DueDate { set; get; }

		[JsonProperty(PropertyName = "metadata", NullValueHandling=NullValueHandling.Ignore)]
		public Dictionary<String, String> Metadata { set; get; }

		[JsonProperty(PropertyName = "customer", NullValueHandling=NullValueHandling.Ignore)]
        public Customer Customer { set; get; }

		[JsonProperty(PropertyName = "use_card_points", NullValueHandling=NullValueHandling.Ignore)]
        public Boolean UseCardPoints { set; get; }
    }
}
