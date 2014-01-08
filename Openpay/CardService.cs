using Openpay.Entities;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class CardService : ResourceService<Card, Card>
    {

        static readonly string merchant_path = "/cards";

        static readonly string customer_path = "/customers/{0}/cards";

        private OpenpayHttpClient httpClient;

        public CardService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {
        }

        internal CardService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
        }

        public override String GetMerchantPath()
        {
            return merchant_path;
        }

        public override String GetCustomerPath()
        {
            return customer_path;
        }

    }
}
