using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class ExchangeRate
    {
        [JsonProperty(PropertyName = "from")]
		public String fromCurrency { get; set; }

        [JsonProperty(PropertyName = "to")]
		public String toCurrency { get; set; }

        [JsonProperty(PropertyName = "date")]
		public DateTime? date { get; set; }

        [JsonProperty(PropertyName = "value")]
		public Decimal value { get; set; }
        
    }
}
