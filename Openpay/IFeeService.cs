using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface IFeeService
    {
        Fee Create(FeeRequest request);
        List<Fee> List(SearchParams filters = null);
        Fee Refund(string charge_id, string description);
    }
}