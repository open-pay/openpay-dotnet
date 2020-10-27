using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface IPayoutService
    {
        void Cancel(string payout_id);
        void Cancel(string customer_id, string payout_id);
        Payout Create(PayoutRequest payout_request);
        Payout Create(string customer_id, PayoutRequest payout_request);
        Payout Get(string payout_id);
        Payout Get(string customer_id, string payout_id);
        List<Payout> List(SearchParams filters = null);
        List<Payout> List(string customer_id, SearchParams filters = null);
    }
}