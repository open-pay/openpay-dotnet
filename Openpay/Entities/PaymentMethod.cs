using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class PaymentMethod
    {
        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "bank")]
        public String BankName { get; set; }

        [JsonProperty(PropertyName = "clabe")]
        public String CLABE { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "reference")]
        public String Reference { get; set; }

        [JsonProperty(PropertyName = "agreement")]
        public String Agreement { get; set; }

    		[JsonProperty(PropertyName = "walmart_reference")]
    		public String WalmartReference { get; set; }

        [JsonProperty(PropertyName = "barcode_url")]
        public String BarcodeURL { get; set; }

    		[JsonProperty(PropertyName = "barcode_walmart_url")]
    		public String BarcodeWalmartURL { get; set; }

        [JsonProperty(PropertyName = "payment_address")]
        public String PaymentAddress { get; set; }

        [JsonProperty(PropertyName = "payment_url_bip21")]
        public String PaymentUrlBip21 { get; set; }

        [JsonProperty(PropertyName = "amount_bitcoins")]
        public Decimal AmountBitcoins { get; set; }

        [JsonProperty(PropertyName = "exchange_rate")]
        public ExchangeRate ExchangeRate { get; set; }

    		[JsonProperty(PropertyName = "url")]
    		public String Url { get; set; }

        [JsonProperty(PropertyName = "ivr_key")]
        public String IvrKey { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public String PhoneNumber { get; set; }
	}
}
