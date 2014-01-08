using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class FeeService : OpenpayResourceService<FeeRequest, Fee>
    {

        public FeeService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {
            ResourceName = "fees";
        }

        internal FeeService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "fees";
        }

        public Fee Create(FeeRequest request)
        {
            return base.Create(null, request);
        }

        public List<Fee> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }
    }
}
