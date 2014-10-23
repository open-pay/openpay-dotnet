using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Store
    {
        [JsonProperty(PropertyName = "reference")]
        public String Reference { get; set; }

        [JsonProperty(PropertyName = "barcode_url")]
        public String BarcodeURL { get; set; }
    }
}
