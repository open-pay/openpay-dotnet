using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{
    public class Customer : OpenpayResourceObject
    {
		[JsonProperty(PropertyName = "external_id", NullValueHandling=NullValueHandling.Ignore)]
        public String ExternalId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }

		[JsonProperty(PropertyName = "last_name", NullValueHandling=NullValueHandling.Ignore)]
        public String LastName { get; set; }

		[JsonProperty(PropertyName = "phone_number", NullValueHandling=NullValueHandling.Ignore)]
        public String PhoneNumber { get; set; }

		[JsonProperty(PropertyName = "address", NullValueHandling=NullValueHandling.Ignore)]
        public Address Address { get; set; }

		[JsonProperty(PropertyName = "status", NullValueHandling=NullValueHandling.Ignore)]
        public String Status { get; set; }

		[JsonProperty(PropertyName = "clabe", NullValueHandling=NullValueHandling.Ignore)]
        public String CLABE { get; set; }

		[JsonProperty(PropertyName = "balance", NullValueHandling=NullValueHandling.Ignore)]
        public Decimal? Balance { get; set; }

		[JsonProperty(PropertyName = "creation_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }
        
		[JsonProperty(PropertyName = "requires_account", NullValueHandling=NullValueHandling.Ignore)]
        public Boolean? RequiresAccount { get; set; }

		[JsonProperty(PropertyName = "store", NullValueHandling=NullValueHandling.Ignore)]
        public Store Store  { get; set; }
    }
}
