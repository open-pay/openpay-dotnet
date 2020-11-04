using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class Gateway : JsonObject
    {
        [JsonProperty(PropertyName = "data", NullValueHandling=NullValueHandling.Ignore)]
        public Dictionary<String, Dictionary<String, String>> Data { get; set; }
    }
}