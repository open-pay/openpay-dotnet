using Newtonsoft.Json;

namespace Openpay.Entities
{
    public class UpdateCheckoutRequest : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "expiration_date", NullValueHandling=NullValueHandling.Ignore)]
        public string ExpirationDate { get; set; }
    }
}