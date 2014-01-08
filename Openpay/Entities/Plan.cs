using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Plan : ResourceObject
    {
        [JsonProperty(PropertyName = "creation_date")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public String Currency { get; set; }

        [JsonProperty(PropertyName = "repeat_every")]
        public int RepeatEvery { get; set; }

        [JsonProperty(PropertyName = "repeat_unit")]
        public int RepeatUnit { get; set; }

        [JsonProperty(PropertyName = "retry_times")]
        public int RetryTimes { get; set; }

        [JsonProperty(PropertyName = "status")]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "status_after_retry")]
        public String StatusAfterRetry { get; set; }

        [JsonProperty(PropertyName = "trial_days")]
        public int TrialDays { get; set; }
    }
}
