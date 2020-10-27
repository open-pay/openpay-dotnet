﻿using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public class TransferService : OpenpayResourceService<TransferRequest, Transfer>, ITransferService
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
