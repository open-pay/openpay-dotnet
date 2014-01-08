using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Subscription : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "creation_date")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "cancel_at_period_end")]
        public Boolean CancelAtPeriodEnd { get; set; }

        [JsonProperty(PropertyName = "charge_date")]
        public DateTime? ChargeDate { get; set; }

        [JsonProperty(PropertyName = "current_period_number")]
        public int CurrentPeriod { get; set; }

        [JsonProperty(PropertyName = "period_end_date")]
        public DateTime? PeriodEndDate { get; set; }

        [JsonProperty(PropertyName = "trial_end_date")]
        public DateTime? TrialEndDate { get; set; }

        [JsonProperty(PropertyName = "plan_id")]
        public String PlanId { get; set; }

        [JsonProperty(PropertyName = "customer_id")]
        public String CustomerId { get; set; }

        [JsonProperty(PropertyName = "card_id")]
        public String CardId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "card")]
        public Card Card { get; set; }
    }
}
