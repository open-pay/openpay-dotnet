using Newtonsoft.Json;
using System;

namespace Openpay.Entities
{

    public class Token : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "card", NullValueHandling=NullValueHandling.Ignore)]
        public Card Card { get; set; }
    }
}