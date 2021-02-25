using Newtonsoft.Json;
using System;

namespace Openpay.Entities
{

    public class CodiOptions
    {
        [JsonProperty(PropertyName = "mode", NullValueHandling=NullValueHandling.Ignore)]
        public String Mode { get; set; }
       
        [JsonProperty(PropertyName = "use_customer_phone", NullValueHandling=NullValueHandling.Ignore)]
        public Boolean UseCustomerPhone { get; set; }
        
        [JsonProperty(PropertyName = "phone_number", NullValueHandling=NullValueHandling.Ignore)]
        public int PhoneNumber { get; set; }
    }
}
