using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class Provider : JsonObject
    {
        [JsonProperty(PropertyName = "name", NullValueHandling=NullValueHandling.Ignore)]
        public String Name { get; set; }
    }
}