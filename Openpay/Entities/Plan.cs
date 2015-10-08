using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Plan : OpenpayResourceObject
    {
		[JsonProperty(PropertyName = "creation_date", NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { get; set; }

		[JsonProperty(PropertyName = "currency", NullValueHandling=NullValueHandling.Ignore)]
        public String Currency { get; set; }

		[JsonProperty(PropertyName = "repeat_every", NullValueHandling=NullValueHandling.Ignore)]
        public int RepeatEvery { get; set; }

		[JsonProperty(PropertyName = "repeat_unit", NullValueHandling=NullValueHandling.Ignore)]
        public String RepeatUnit { get; set; }

		[JsonProperty(PropertyName = "retry_times", NullValueHandling=NullValueHandling.Ignore)]
        public int RetryTimes { get; set; }

		[JsonProperty(PropertyName = "status", NullValueHandling=NullValueHandling.Ignore)]
        public String Status { get; set; }

		[JsonProperty(PropertyName = "status_after_retry", NullValueHandling=NullValueHandling.Ignore)]
        public String StatusAfterRetry { get; set; }

		[JsonProperty(PropertyName = "trial_days", NullValueHandling=NullValueHandling.Ignore)]
        public int TrialDays { get; set; }
    }
}
