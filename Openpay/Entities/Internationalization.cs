using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class Internationalization : JsonObject
    {
        [JsonProperty(PropertyName = "locale", NullValueHandling=NullValueHandling.Ignore)]
        public String Locale { get; set; }

        [JsonProperty(PropertyName = "timezone", NullValueHandling=NullValueHandling.Ignore)]
        public String Timezone { get; set; }
    }
}
