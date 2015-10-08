using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class CardPoints 
    {

        [JsonProperty(PropertyName = "used")]
        public Decimal Used { get; set; }

        [JsonProperty(PropertyName = "remaining")]
        public Decimal Remaining { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { get; set; }

		[JsonProperty(PropertyName = "caption", NullValueHandling=NullValueHandling.Ignore)]
        public String Caption { get; set; }
       
    }
}
