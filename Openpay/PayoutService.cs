using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace Openpay
{
    public class PayoutService : OpenpayResourceService<PayoutRequest, Payout>
    {

        public PayoutService(string api_key, string merchant_id, Countries country, bool production = false)
            : base(api_key, merchant_id, country, production)
        {
            ResourceName = "payouts";
        }

        internal PayoutService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "payouts";
        }

        public Payout Create(PayoutRequest payout_request)
        {
            return base.Create(null, payout_request);
        }

        public new Payout Create(string customer_id, PayoutRequest payout_request)
        {
            return base.Create(customer_id, payout_request);
        }

        public new Payout Get(string customer_id, string payout_id)
        {
            return base.Get(customer_id, payout_id);
        }

        public Payout Get(string payout_id)
        {
            return base.Get(null, payout_id);
        }

		public void Cancel(string customer_id, string payout_id)
		{
			base.Delete(customer_id, payout_id);
		}

		public void Cancel(string payout_id)
		{
			base.Delete(null, payout_id);
		}

        public new List<Payout> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }

        public List<Payout> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }
      
    }
}
