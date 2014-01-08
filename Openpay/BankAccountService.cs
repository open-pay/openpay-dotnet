using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openpay.Entities;

namespace Openpay
{
    public class BankAccountService : ResourceService<BankAccount, BankAccount>
    {

        static readonly string merchant_path = "/bankaccounts";

        static readonly string customer_path = "/customers/{0}/bankaccounts";

        public BankAccountService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {

        }

        internal BankAccountService(OpenpayHttpClient opHttpClient)
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
