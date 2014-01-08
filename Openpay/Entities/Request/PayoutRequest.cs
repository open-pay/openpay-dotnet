using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
     [JsonObject(MemberSerialization.OptIn)]
    public class PayoutRequest : JsonObject
    {

         [JsonProperty(PropertyName = "method")]
         public String Method { set; get; }

         [JsonProperty(PropertyName = "destination_id")]
         public String DestinationId { set; get; }

         [JsonProperty(PropertyName = "card")]
         public Card Card { set; get; }

         [JsonProperty(PropertyName = "bank_account")]
         public BankAccount BankAccount { set; get; }

         [JsonProperty(PropertyName = "amount")]
         public Decimal Amount { set; get; }

         [JsonProperty(PropertyName = "description")]
         public String Description { set; get; }

         [JsonProperty(PropertyName = "order_id")]
         public String OrderId { set; get; }
    }
}
