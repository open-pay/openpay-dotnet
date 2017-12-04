using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class Affiliation
    {
        [JsonProperty(PropertyName = "number", NullValueHandling=NullValueHandling.Ignore)]
        public String Number { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling=NullValueHandling.Ignore)]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "merchant_name", NullValueHandling=NullValueHandling.Ignore)]
        public String MerchantName { get; set; }

    }
}
