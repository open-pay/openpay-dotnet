using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class CustomerAddress : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "department")]
        public String Department { get; set; }

        [JsonProperty(PropertyName = "city")]
        public String City { get; set; }

        [JsonProperty(PropertyName = "additional")]
        public String Additional { get; set; }

    }
}
