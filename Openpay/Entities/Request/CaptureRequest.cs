using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Openpay.Entities.Request
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class CaptureRequest : OpenpayObject
    {
        [JsonProperty(PropertyName = "amount")]
        public Decimal? Amount { set; get; }
    }
}
