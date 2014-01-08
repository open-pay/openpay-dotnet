using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class BankAccount : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "creation_date")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "alias")]
        public String Alias { get; set; }

        [JsonProperty(PropertyName = "clabe")]
        public String CLABE { get; set; }

        [JsonProperty(PropertyName = "holder_name")]
        public String HolderName { get; set; }

        [JsonProperty(PropertyName = "bank_name")]
        public String BankName { get; set; }

        [JsonProperty(PropertyName = "bank_code")]
        public String BankCode { get; set; }
    }
}
