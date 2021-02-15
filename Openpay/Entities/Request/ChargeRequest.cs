using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChargeRequest : JsonObject
    {
        public ChargeRequest()
        {
            Capture = true;
            Confirm = "true";
        }


        [JsonProperty(PropertyName = "method")]
        public String Method { set; get; }

        [JsonProperty(PropertyName = "source_id", NullValueHandling = NullValueHandling.Ignore)]
        public String SourceId { set; get; }

        [JsonProperty(PropertyName = "card", NullValueHandling = NullValueHandling.Ignore)]
        public Card Card { set; get; }

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { set; get; }

        [JsonProperty(PropertyName = "description")]
        public String Description { set; get; }

        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public String OrderId { set; get; }

        [JsonProperty(PropertyName = "capture", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean Capture { set; get; }

        [JsonProperty(PropertyName = "device_session_id", NullValueHandling = NullValueHandling.Ignore)]
        public String DeviceSessionId { set; get; }

        [JsonProperty(PropertyName = "currency", NullValueHandling = NullValueHandling.Ignore)]
        public String Currency { set; get; }

        [JsonProperty(PropertyName = "due_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DueDate { set; get; }

        [JsonProperty(PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<String, String> Metadata { set; get; }

        [JsonProperty(PropertyName = "customer", NullValueHandling = NullValueHandling.Ignore)]
        public Customer Customer { set; get; }

        [JsonProperty(PropertyName = "use_card_points", NullValueHandling = NullValueHandling.Ignore)]
        public String UseCardPoints { set; get; }

        [JsonProperty(PropertyName = "payment_plan", NullValueHandling = NullValueHandling.Ignore)]
        public DeferralPayments DeferralPayments { set; get; }

        [JsonProperty(PropertyName = "confirm", NullValueHandling = NullValueHandling.Ignore)]
        public String Confirm { set; get; }

        [JsonProperty(PropertyName = "send_email", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean SendEmail { set; get; }

        [JsonProperty(PropertyName = "use_3d_secure", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean Use3DSecure { set; get; }

        [JsonProperty(PropertyName = "redirect_url", NullValueHandling = NullValueHandling.Ignore)]
        public String RedirectUrl { set; get; }

        [JsonProperty(PropertyName = "affiliation", NullValueHandling = NullValueHandling.Ignore)]
        public Affiliation Affiliation { set; get; }

        [JsonProperty(PropertyName = "is_phone_order", NullValueHandling = NullValueHandling.Ignore)]
        public Boolean IsPhoneOrder { set; get; }

        [JsonProperty(PropertyName = "payment_options", NullValueHandling = NullValueHandling.Ignore)]
        public String PaymentOptions { set; get; }

        [JsonProperty(PropertyName = "cvv2", NullValueHandling = NullValueHandling.Ignore)]
        public String Cvv2 { set; get; }

        [JsonProperty(PropertyName = "i18n", NullValueHandling = NullValueHandling.Ignore)]
        public Internationalization Internationalization { set; get; }

        [JsonProperty(PropertyName = "gateway", NullValueHandling = NullValueHandling.Ignore)]
        public Gateway Gateway { set; get; }

        [JsonProperty(PropertyName = "provider", NullValueHandling = NullValueHandling.Ignore)]
        public Provider Provider { set; get; }
        
        [JsonProperty(PropertyName = "codi_options", NullValueHandling = NullValueHandling.Ignore)] 
        public CodiOptions CodiOptions { set; get; }
    }
}