using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class BankAccount : OpenpayResourceObject
    {
		[JsonProperty(PropertyName = "creation_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }

		[JsonProperty(PropertyName = "alias", NullValueHandling=NullValueHandling.Ignore)]
        public String Alias { get; set; }

        [JsonProperty(PropertyName = "clabe")]
        public String CLABE { get; set; }

        [JsonProperty(PropertyName = "holder_name")]
        public String HolderName { get; set; }

		[JsonProperty(PropertyName = "bank_name", NullValueHandling=NullValueHandling.Ignore)]
        public String BankName { get; set; }

		[JsonProperty(PropertyName = "bank_code", NullValueHandling=NullValueHandling.Ignore)]
        public String BankCode { get; set; }
    }
}
