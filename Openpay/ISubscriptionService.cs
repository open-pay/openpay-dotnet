using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface ISubscriptionService
    {
        Subscription Create(string customer_id, Subscription subscription);
        void Delete(string customer_id, string subscription_id);
        Subscription Get(string customer_id, string subscription_id);
        List<Subscription> List(string customer_id, SearchParams filters = null);
        Subscription Update(string customer_id, Subscription subscription);
    }
}