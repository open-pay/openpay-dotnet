using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface ITransferService
    {
        Transfer Create(string customer_id, TransferRequest request);
        Transfer Get(string customer_id, string transfer_id);
        List<Transfer> List(string customer_id, SearchParams filters = null);
    }
}