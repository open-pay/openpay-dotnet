using Newtonsoft.Json;
using System;

namespace Openpay.Entities
{
    public class CheckoutRequest : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { get; set; }
        
        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }

        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public String OrderId { get; set; }
        
        [JsonProperty(PropertyName = "currency")]
        public String Currency { get; set; }

        [JsonProperty(PropertyName = "redirect_url")]
        public String RedirectUrl { get; set; }
        
        [JsonProperty(PropertyName = "expiration_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty(PropertyName = "send_email", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean SendEmail { get; set; }

        [JsonProperty(PropertyName = "customer", NullValueHandling = NullValueHandling.Ignore)]
        public Customer Customer { get; set; }
    }
}