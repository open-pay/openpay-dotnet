using Newtonsoft.Json;
using System;

namespace Openpay.Entities
{
    public class TokenRequest : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "holder_name")]
        public String HolderName { get; set; }
        
        [JsonProperty(PropertyName = "card_number")]
        public String CardNumber { get; set; }

        [JsonProperty(PropertyName = "cvv2")]
        public String Cvv2 { get; set; }
        
        [JsonProperty(PropertyName = "expiration_month")]
        public String ExpirationMonth { get; set; }

        [JsonProperty(PropertyName = "expiration_year")]
        public String ExpirationYear { get; set; }
        
        [JsonProperty(PropertyName = "address", NullValueHandling=NullValueHandling.Ignore)]
        public Address Address  { get; set; }
    }
}