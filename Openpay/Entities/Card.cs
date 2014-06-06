using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Card : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "token_id")]
        public String TokenId { get; set; }

        [JsonProperty(PropertyName = "creation_date")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "bank_name")]
        public String BankName { get; set; }

        [JsonProperty(PropertyName = "allows_payouts")]
        public Boolean AllowsPayouts { get; set; }

        [JsonProperty(PropertyName = "holder_name")]
        public String HolderName { get; set; }

        [JsonProperty(PropertyName = "expiration_month")]
        public String ExpirationMonth { get; set; }

        [JsonProperty(PropertyName = "expiration_year")]
        public String ExpirationYear { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address;

        [JsonProperty(PropertyName = "card_number")]
        public String CardNumber { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public String Brand { get; set; }

        [JsonProperty(PropertyName = "allows_charges")]
        public Boolean AllowsCharges { get; set; }

        [JsonProperty(PropertyName = "bank_code")]
        public String BankCode { get; set; }

        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "cvv2")]
        public String Cvv2 { set; get; }
    }
}
