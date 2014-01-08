using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace Openpay
{
    public class BankAccountService : OpenpayResourceService<BankAccount, BankAccount>
    {

        public BankAccountService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {
            ResourceName = "bankaccounts";
        }

        internal BankAccountService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "bankaccounts";
        }

        public BankAccount Create(string customer_id, BankAccount bankAccount)
        {
            return base.Create(customer_id, bankAccount);
        }

        public BankAccount Create(BankAccount bankAccount)
        {
            return base.Create(null, bankAccount);
        }

       

        public void Delete(string customer_id, string bankAccount_id)
        {
            base.Delete(customer_id, bankAccount_id);
        }

        public void Delete(string bankAccount_id)
        {
            base.Delete(null, bankAccount_id);
        }

        public BankAccount Get(string customer_id, string bankAccount_id)
        {
            return base.Get(customer_id, bankAccount_id);
        }

        public BankAccount Get(string bankAccount_id)
        {
            return base.Get(null, bankAccount_id);
        }

        public List<BankAccount> List(string customer_id, SearchParams filters = null)
        {
            return base.List(customer_id, filters);
        }

        public List<BankAccount> List(SearchParams filters = null)
        {
            return base.List(null, filters);
        }
    }
}
