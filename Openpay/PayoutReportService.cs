﻿using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;

namespace Openpay
{
    public class PayoutReportService : OpenpayGenericService, IPayoutReportService
    {

        public PayoutReportService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production) { }

        internal PayoutReportService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient) { }

        public PayoutSummary Get(string payout_id)
        {
            return base.Get<PayoutSummary>("/reports/payout/" + payout_id);
        }

        public List<Transaction> Detail(string payout_id, PayoutReportDetailSearchParams searchParams)
        {
            string url = "/reports/payout/" + payout_id + "/detail";
            if (searchParams != null)
            {
                if (searchParams.Offset < 0)
                    throw new ArgumentOutOfRangeException("offset");
                if (searchParams.Limit < 1 || searchParams.Limit > 100)
                    throw new ArgumentOutOfRangeException("limit");
                url = ParameterBuilder.ApplyParameterToUrl(url, "limit", searchParams.Limit.ToString());
                url = ParameterBuilder.ApplyParameterToUrl(url, "offset", searchParams.Offset.ToString());
                if (searchParams.DetailType != null)
                    url = ParameterBuilder.ApplyParameterToUrl(url, "detail_type", searchParams.DetailType);
            }
            return base.List<Transaction>(url);
        }

    }
}
