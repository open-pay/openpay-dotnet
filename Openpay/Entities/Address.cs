using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Address
    {
        [JsonProperty(PropertyName = "postal_code")]
        public String PostalCode { get; set; }

        [JsonProperty(PropertyName = "line1")]
        public String Line1 { get; set; }

		[JsonProperty(PropertyName = "line2", NullValueHandling=NullValueHandling.Ignore)]
        public String Line2 { get; set; }

		[JsonProperty(PropertyName = "line3", NullValueHandling=NullValueHandling.Ignore)]
        public String Line3 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public String City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public String State { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public String CountryCode { get; set; }
    }
}
