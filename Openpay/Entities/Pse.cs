using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Pse : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "redirect_url")]
        public String RedirectUrl { get; set; }

    }
}
