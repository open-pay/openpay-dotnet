using Newtonsoft.Json;
using System;

namespace Openpay.Entities
{

    public class Checkout : OpenpayResourceObject
    {
		[JsonProperty(PropertyName = "amount", NullValueHandling=NullValueHandling.Ignore)]
        public Decimal Amount { get; set; }

		[JsonProperty(PropertyName = "description", NullValueHandling=NullValueHandling.Ignore)]
        public String Description { get; set; }

		[JsonProperty(PropertyName = "order_id", NullValueHandling=NullValueHandling.Ignore)]
        public String OrderId { get; set; }

		[JsonProperty(PropertyName = "currency", NullValueHandling=NullValueHandling.Ignore)]
        public String Currency { get; set; }
        
        [JsonProperty(PropertyName = "status", NullValueHandling=NullValueHandling.Ignore)]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "checkout_link", NullValueHandling=NullValueHandling.Ignore)]
        public String CheckoutLink { get; set; }

        [JsonProperty(PropertyName = "creation_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }
        
        [JsonProperty(PropertyName = "expiration_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? ExpirationDate { get; set; }
        
        [JsonProperty(PropertyName = "customer", NullValueHandling=NullValueHandling.Ignore)]
        public Customer Customer { get; set; }
    }
}
