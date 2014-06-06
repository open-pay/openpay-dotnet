using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class Customer : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "external_id")]
        public String ExternalId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public String LastName { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public String PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "status")]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "clabe")]
        public String CLABE { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public Decimal Balance { get; set; }

        [JsonProperty(PropertyName = "creation_date")]
        public DateTime? CreationDate { get; set; }
        
        [JsonProperty(PropertyName = "requires_account")]
        public Boolean RequiresAccount { get; set; }
    }
}
