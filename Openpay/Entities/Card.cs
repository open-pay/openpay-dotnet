using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Card : OpenpayResourceObject
    {
		[JsonProperty(PropertyName = "token_id", NullValueHandling=NullValueHandling.Ignore)]
        public String TokenId { get; set; }

		[JsonProperty(PropertyName = "creation_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }

		[JsonProperty(PropertyName = "bank_name", NullValueHandling=NullValueHandling.Ignore)]
        public String BankName { get; set; }

		[JsonProperty(PropertyName = "allows_payouts", NullValueHandling=NullValueHandling.Ignore)]
        public Boolean AllowsPayouts { get; set; }

        [JsonProperty(PropertyName = "holder_name")]
        public String HolderName { get; set; }

        [JsonProperty(PropertyName = "expiration_month")]
        public String ExpirationMonth { get; set; }

        [JsonProperty(PropertyName = "expiration_year")]
        public String ExpirationYear { get; set; }

		[JsonProperty(PropertyName = "address", NullValueHandling=NullValueHandling.Ignore)]
        public Address Address;

        [JsonProperty(PropertyName = "card_number")]
        public String CardNumber { get; set; }

		[JsonProperty(PropertyName = "brand", NullValueHandling=NullValueHandling.Ignore)]
        public String Brand { get; set; }

		[JsonProperty(PropertyName = "allows_charges", NullValueHandling=NullValueHandling.Ignore)]
        public Boolean AllowsCharges { get; set; }

		[JsonProperty(PropertyName = "bank_code", NullValueHandling=NullValueHandling.Ignore)]
        public String BankCode { get; set; }

		[JsonProperty(PropertyName = "type", NullValueHandling=NullValueHandling.Ignore)]
        public String Type { get; set; }

		[JsonProperty(PropertyName = "cvv2", NullValueHandling=NullValueHandling.Ignore)]
        public String Cvv2 { set; get; }

		[JsonProperty(PropertyName = "device_session_id", NullValueHandling=NullValueHandling.Ignore)]
        public String DeviceSessionId { set; get; }

		[JsonProperty(PropertyName = "points_card", NullValueHandling=NullValueHandling.Ignore)]
		public Boolean PointsCard { set; get; }

		[JsonProperty(PropertyName = "points_type", NullValueHandling=NullValueHandling.Ignore)]
		public String PointsType { set; get; }

		[JsonProperty(PropertyName = "affiliation")]
		public Affiliation Affiliation { set; get; }

        [JsonProperty(PropertyName = "payment_options", NullValueHandling=NullValueHandling.Ignore)]
        public String PaymentOptions { set; get; }
    }
}
