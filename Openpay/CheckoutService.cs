using System.Collections.Generic;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace Openpay
{
    public class CheckoutService : OpenpayResourceService<CheckoutRequest, Checkout>
    {

        public CheckoutService(string api_key, string merchant_id, Countries country, bool production = false)
            : base(api_key, merchant_id, country, production)
        {
            ResourceName = "checkouts";
        }

        internal CheckoutService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "checkouts";
        }

        public Checkout Create(CheckoutRequest charge_request)
        {
            
            return base.Create(null, charge_request);
        }

        public new Checkout Create(string customer_id, CheckoutRequest checkout_request)
        { 
            return base.Create(customer_id, checkout_request);
        }

        public Checkout Get(string checkout_id)
        {
            return base.Get(null, checkout_id);
        }
        
        public Checkout Update(Checkout checkout, string status, UpdateCheckoutRequest new_data)
        {
            return base.UpdateCheckout(status, new_data, checkout);
        }

        public new List<Checkout> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }

        public List<Checkout> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }
    }
}
