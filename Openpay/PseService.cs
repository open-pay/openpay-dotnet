using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace Openpay
{
    public class PseService : OpenpayResourceService<PseRequest, Pse>
    {

        public PseService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {
            ResourceName = "pse";
        }

        internal PseService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "pse";
        }

        public new Pse Create(string customer_id, PseRequest pse_request)
        {
            return base.Create(customer_id, pse_request);
        }

        public Pse Create(PseRequest pse_request)
        {
            return base.Create(null, pse_request);
        }

    }
}
