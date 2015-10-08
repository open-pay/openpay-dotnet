using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class OpenpayResourceObject : JsonObject
    {
		[JsonProperty(PropertyName = "id", NullValueHandling=NullValueHandling.Ignore)]
        public String Id { get; set; }
    }
}
