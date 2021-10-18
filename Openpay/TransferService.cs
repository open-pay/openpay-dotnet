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

        public TransferService(string api_key, string merchant_id, Countries country, bool production = false)
            : base(api_key, merchant_id, country, production)
        {
            ResourceName = "transfers";
        }

        internal TransferService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "transfers";
        }

        public new Transfer Create(string customer_id, TransferRequest request)
        {
            return base.Create(customer_id, request);
        }

        public new Transfer Get(string customer_id, string transfer_id)
        {
            return base.Get(customer_id, transfer_id);
        }

        public new List<Transfer> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }
    }
}
