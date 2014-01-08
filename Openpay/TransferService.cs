using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class TransferService : OpenpayResourceService<TransferRequest, Transfer>
    {

        public TransferService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {
            ResourceName = "transfers";
        }

        internal TransferService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "transfers";
        }

        public Transfer Create(string customer_id, TransferRequest request)
        {
            return base.Create(customer_id, request);
        }

        public Transfer Get(string customer_id, string transfer_id)
        {
            return base.Get(customer_id, transfer_id);
        }

        public List<Transfer> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }
    }
}
