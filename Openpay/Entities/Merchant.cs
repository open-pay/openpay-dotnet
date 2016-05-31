using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class Merchant : OpenpayResourceObject
    {
		
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }

		[JsonProperty(PropertyName = "phone", NullValueHandling=NullValueHandling.Ignore)]
        public String Phone { get; set; }

		[JsonProperty(PropertyName = "status", NullValueHandling=NullValueHandling.Ignore)]
        public String Status { get; set; }

		[JsonProperty(PropertyName = "clabe", NullValueHandling=NullValueHandling.Ignore)]
        public String CLABE { get; set; }

		[JsonProperty(PropertyName = "balance", NullValueHandling=NullValueHandling.Ignore)]
        public Decimal Balance { get; set; }

		[JsonProperty(PropertyName = "creation_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "available_funds", NullValueHandling = NullValueHandling.Ignore)]
        public Decimal AvailableFunds { get; set; }
		
    }
}
