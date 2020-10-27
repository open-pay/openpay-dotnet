using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface IChargeService
    {
        Charge CancelByMerchant(string merchant_id, string charge_id, ChargeRequest charge_request);
        Charge Capture(string charge_id, decimal? amount);
        Charge Capture(string customer_id, string charge_id, decimal? amount);
        Charge Create(ChargeRequest charge_request);
        Charge Create(string customer_id, ChargeRequest charge_request);
        Charge Get(string charge_id);
        Charge Get(string customer_id, string charge_id);
        List<Charge> List(SearchParams filters = null);
        List<Charge> List(string customer_id, SearchParams filters = null);
        Charge Refund(string charge_id, string description);
        Charge Refund(string charge_id, string description, decimal? amount);
        Charge Refund(string customer_id, string charge_id, string description);
        Charge Refund(string customer_id, string charge_id, string description, decimal? amount);
    }
}