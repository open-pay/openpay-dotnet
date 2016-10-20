using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Subscription : OpenpayResourceObject
    {
		[JsonProperty(PropertyName = "creation_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }

		[JsonProperty(PropertyName = "cancel_at_period_end", NullValueHandling=NullValueHandling.Ignore)]
        public Boolean CancelAtPeriodEnd { get; set; }

		[JsonProperty(PropertyName = "charge_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? ChargeDate { get; set; }

		[JsonProperty(PropertyName = "current_period_number", NullValueHandling=NullValueHandling.Ignore)]
        public int CurrentPeriod { get; set; }

		[JsonProperty(PropertyName = "period_end_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? PeriodEndDate { get; set; }

		[JsonProperty(PropertyName = "trial_end_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? TrialEndDate { get; set; }

        [JsonProperty(PropertyName = "plan_id")]
        public String PlanId { get; set; }

		[JsonProperty(PropertyName = "customer_id", NullValueHandling=NullValueHandling.Ignore)]
        public String CustomerId { get; set; }

		[JsonProperty(PropertyName = "card_id", NullValueHandling=NullValueHandling.Ignore)]
        public String CardId { get; set; }

		[JsonProperty(PropertyName = "status", NullValueHandling=NullValueHandling.Ignore)]
        public String Status { get; set; }

		[JsonProperty(PropertyName = "card", NullValueHandling=NullValueHandling.Ignore)]
        public Card Card { get; set; }

		[JsonProperty(PropertyName = "transaction", NullValueHandling = NullValueHandling.Ignore)]
		public Transaction Transaction { get; set; }

    }
}
