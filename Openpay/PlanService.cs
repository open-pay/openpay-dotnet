using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class PlanService : OpenpayResourceService<Plan, Plan>
    {

        public PlanService(string api_key, string merchant_id, Countries country, bool production = false)
            : base(api_key, merchant_id, country, production)
        {
            ResourceName = "plans";
        }

        internal PlanService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "plans";
        }

        public Plan Create(Plan plan)
        {
            return base.Create(null, plan);
        }

        public Plan Update(Plan plan)
        {
            return base.Update(null, plan);
        }

        public void Delete(string plan_id)
        {
            base.Delete(null, plan_id);
        }

        public Plan Get(string plan_id)
        {
            return base.Get(null, plan_id);
        }

        public List<Plan> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }

        public List<Subscription> Subscriptions(string plan_id, SearchParams filters = null)
        {
            string url = GetEndPoint(null, plan_id) + "/subscriptions";
            url = url + BuildParams(filters);
            return this.httpClient.Get<List<Subscription>>(url);
        }
    }
}
