using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface IPayoutReportService
    {
        List<Transaction> Detail(string payout_id, PayoutReportDetailSearchParams searchParams);
        PayoutSummary Get(string payout_id);
    }
}