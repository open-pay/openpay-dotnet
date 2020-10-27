using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace Openpay
{
    public interface IBankAccountService
    {
        BankAccount Create(BankAccount bankAccount);
        BankAccount Create(string customer_id, BankAccount bankAccount);
        void Delete(string bankAccount_id);
        void Delete(string customer_id, string bankAccount_id);
        BankAccount Get(string bankAccount_id);
        BankAccount Get(string customer_id, string bankAccount_id);
        List<BankAccount> List(SearchParams filters = null);
        List<BankAccount> List(string customer_id, SearchParams filters = null);
    }
}