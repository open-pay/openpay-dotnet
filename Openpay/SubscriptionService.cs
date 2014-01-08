using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class SubscriptionService : OpenpayResourceService<Subscription, Subscription>
    {

        public SubscriptionService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {
            ResourceName = "subscriptions";
        }

        internal SubscriptionService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "subscriptions";
        }

        public Subscription Create(string customer_id, Subscription subscription)
        {
            return base.Create(customer_id, subscription);
        }

        public Subscription Update(string customer_id, Subscription subscription)
        {
            return base.Update(customer_id, subscription);
        }

        public void Delete(string customer_id, string subscription_id)
        {
            base.Delete(customer_id, subscription_id);
        }

        public Subscription Get(string customer_id, string subscription_id)
        {
            return base.Get(customer_id, subscription_id);
        }

        public List<Subscription> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }
    }
}
