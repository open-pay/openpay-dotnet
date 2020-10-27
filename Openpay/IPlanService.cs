using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface IPlanService
    {
        Plan Create(Plan plan);
        void Delete(string plan_id);
        Plan Get(string plan_id);
        List<Plan> List(SearchParams filters = null);
        List<Subscription> Subscriptions(string plan_id, SearchParams filters = null);
        Plan Update(Plan plan);
    }
}