using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class MerchantService : OpenpayResourceService<Merchant, Merchant>
    {

        public MerchantService(string api_key, string merchant_id, string publicIp, Countries country, bool production = false)
            : base(api_key, merchant_id,publicIp, country, production)
        {
            ResourceName = "";
        }

        internal MerchantService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "";
        }

        public Merchant Get()
        {
            return base.Get(null, null);
        }
       
    }
}
