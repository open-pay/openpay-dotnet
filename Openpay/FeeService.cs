﻿using Openpay.Entities;
using Openpay.Entities.Request;
using System;
using System.Collections.Generic;

namespace Openpay
{
    public class FeeService : OpenpayResourceService<FeeRequest, Fee>, IFeeService
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

        public Fee Refund(string charge_id, string description)
        {
            if (charge_id == null)
                throw new ArgumentNullException("charge_id cannot be null");
            string ep = GetEndPoint(null, charge_id) + "/refund";

            RefundRequest request = new RefundRequest();
            request.Description = description;

            return this.httpClient.Post<Fee>(ep, request);
        }

    }
}
