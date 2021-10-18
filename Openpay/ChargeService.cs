using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace Openpay
{
    public class ChargeService : OpenpayResourceService<ChargeRequest, Charge>
    {

        public ChargeService(string api_key, string merchant_id, Countries country, bool production = false)
            : base(api_key, merchant_id, country, production)
        {
            ResourceName = "charges";
        }

        internal ChargeService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "charges";
        }

        public Charge Refund(string charge_id, string description)
        {
            return this.Refund(null, charge_id, description);
        }

		public Charge Refund(string charge_id, string description, Decimal? amount)
		{
			return this.Refund(null, charge_id, description, amount);
		}

		public Charge Refund(string customer_id, string charge_id, string description)
        {
            return this.Refund(customer_id, charge_id, description, null);
		}

		public Charge Refund(string customer_id, string charge_id, string description, Decimal? amount)
		{
			return this.Refund(customer_id, charge_id, description, amount, null);
		}

		public Charge Refund(string customer_id, string charge_id, string description, Decimal? amount, Gateway gateway)
		{
			if (charge_id == null)
				throw new ArgumentNullException("charge_id cannot be null");
			string ep = GetEndPoint(customer_id, charge_id) + "/refund";
			RefundRequest request = new RefundRequest();
			request.Description = description;

			if (amount != null)
				request.Amount = amount;
			if (gateway != null)
				request.Gateway = gateway;
			
			return this.httpClient.Post<Charge>(ep, request);
		}

		public Charge RefundWithRequest(string charge_id, RefundRequest refund_request)
		{
			return this.RefundWithRequest(null, charge_id, refund_request);
		}

		public Charge RefundWithRequest(string customer_id, string charge_id, RefundRequest refund_request)
		{
			if (charge_id == null)
				throw new ArgumentNullException("charge_id cannot be null");
			string ep = GetEndPoint(customer_id, charge_id) + "/refund";
			return this.httpClient.Post<Charge>(ep, refund_request);
		}

        public Charge Capture(string charge_id, Decimal? amount)
        {
            return this.Capture(null, charge_id, amount);
        }

        public Charge Capture(string customer_id , string charge_id, Decimal? amount)
        {
            if (charge_id == null)
                throw new ArgumentNullException("charge_id cannot be null");
            string ep = GetEndPoint(customer_id, charge_id) + "/capture";
            CaptureRequest request = new CaptureRequest();
            request.Amount = amount;
            return this.httpClient.Post<Charge>(ep, request);
        }

        public Charge Create(ChargeRequest charge_request)
        {
            return base.Create(null, charge_request);
        }

        public new Charge Create(string customer_id, ChargeRequest charge_request)
        { 
            return base.Create(customer_id, charge_request);
        }

        public Charge CancelByMerchant(string merchant_id, string charge_id, ChargeRequest charge_request)
        {
             return base.CancelByMerchant(merchant_id, charge_id,  charge_request);
        }

        public new Charge Get(string customer_id, string charge_id)
        {
            return base.Get(customer_id, charge_id);
        }

        public Charge Get(string charge_id)
        {
            return base.Get(null, charge_id);
        }

        public new List<Charge> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }

        public List<Charge> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }
      
    }
}
