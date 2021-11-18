using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public abstract class OpenpayResourceService<T, R>
        where T : JsonObject
        where R : OpenpayResourceObject
    {
        protected OpenpayHttpClient httpClient;

        private static readonly string filter_date_format = "yyyy-MM-dd";

        private static readonly string filter_amount_format = "0.00";

        public OpenpayResourceService(string api_key, string merchant_id, Countries country, bool production = false)
        {
            this.httpClient = new OpenpayHttpClient(api_key, merchant_id, country, production);
        }

        internal OpenpayResourceService(OpenpayHttpClient opHttpClient)
        {
            this.httpClient = opHttpClient;
        }

        protected String ResourceName { get; set; }

        protected String GetEndPoint(string customer_id, string resource_id = null)
        {
            string ep = "/" + ResourceName.ToLower();
            if (customer_id != null)
            {
                ep = String.Format("/customers/{0}" + ep, customer_id);
            }
            if (resource_id != null)
            {
                ep = ep + "/" + resource_id;
            }
            return ep;
        }

        protected String GetEndPointMerchant(string merchant_id, string resource_id = null)
        {
            string ep = "/" + ResourceName.ToLower();
            /*if (merchant_id != null)
            {
                ep = String.Format(merchant_id + ep);
            }*/
            if (resource_id != null)
            {
                ep += "/" + resource_id;
            }
            return ep;
        }

        protected virtual R Create(string customer_id, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to create is null");
            string ep = GetEndPoint(customer_id);
            return this.httpClient.Post<R>(ep, obj);
        }

        protected R Update(string customer_id, R obj)
        {
            if (String.IsNullOrEmpty(obj.Id))
                throw new ArgumentNullException("resource_id");
            if (obj == null)
                throw new ArgumentNullException("Object is null");

            string ep = GetEndPoint(customer_id, obj.Id);
            return this.httpClient.Put<R>(ep, obj);
        }
        
        protected R UpdateCheckout(string status, UpdateCheckoutRequest new_data, R obj)
        {
            if (String.IsNullOrEmpty(obj.Id))
                throw new ArgumentNullException("resource_id");
            if (obj == null)
                throw new ArgumentNullException("Object is null");

            string ep = GetEndPoint(null, obj.Id);
            ep = ep + "?status=" + status;
            return this.httpClient.Put<R>(ep, new_data);
        }

        protected virtual R Cancel(string customer_id, string charge_id, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to create is null");
            string ep = GetEndPoint(customer_id, charge_id)+"/cancel";
            return this.httpClient.Cancel<R>(ep, obj);
        }

        protected virtual R CancelByMerchant(string merchant_id, string charge_id, T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to create is null");
            string ep = GetEndPointMerchant(merchant_id, charge_id) + "/cancel";
            return this.httpClient.Cancel<R>(ep, obj);
        }

        protected virtual void Delete(string customer_id, string resource_id)
        {
            if (String.IsNullOrEmpty(resource_id))
                throw new ArgumentNullException("The id of the object cannot be null");
            string ep = GetEndPoint(customer_id, resource_id);
            this.httpClient.Delete(ep);
        }

        protected virtual R Get(string customer_id, string resource_id)
        {
            string ep = GetEndPoint(customer_id, resource_id);
            return this.httpClient.Get<R>(ep);
        }

        protected List<R> List(string customer_id, SearchParams searchParams)
        {
            string url = GetEndPoint(customer_id);
            url = url + BuildParams(searchParams);
            return this.httpClient.Get<List<R>>(url);
        }

        protected string BuildParams(SearchParams searchParams)
        {
            string url_params = string.Empty;
            if (searchParams != null)
            {
                if (searchParams.Offset < 0)
                    throw new ArgumentOutOfRangeException("offset");
                if (searchParams.Limit < 1 || searchParams.Limit > 100)
                    throw new ArgumentOutOfRangeException("limit");

                url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "limit", searchParams.Limit.ToString());
                url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "offset", searchParams.Offset.ToString());

                if (searchParams.OrderId != null)
					url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "order_id", searchParams.OrderId);

				if (searchParams.Status != null)
					url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "status", searchParams.Status.ToString());
                
                if (searchParams.StartDate != null)
                    url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "startDate", searchParams.StartDate);
                
                if (searchParams.EndDate != null)
                    url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "endDate", searchParams.EndDate);

                if (searchParams.Creation != DateTime.MinValue)
                    url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "creation", searchParams.Creation.ToString(filter_date_format));

                if (searchParams.CreationGte != DateTime.MinValue)
                    url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "creation[gte]", searchParams.CreationGte.ToString(filter_date_format));

                if (searchParams.CreationLte != DateTime.MinValue)
                    url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "creation[lte]", searchParams.CreationLte.ToString(filter_date_format));

                if (searchParams.Amount > 0)
                    url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "amount", searchParams.Amount.ToString(filter_amount_format));

                if (searchParams.AmountGte > 0)
                    url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "amount[gte]", searchParams.AmountGte.ToString(filter_amount_format));

                if (searchParams.AmountLte > 0)
					url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "amount[lte]", searchParams.AmountLte.ToString(filter_amount_format));


			}
            return url_params;
        }
    }
}
