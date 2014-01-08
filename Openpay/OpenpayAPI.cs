using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
    public class OpenpayAPI
    {
        public CustomerService CustomerService { get; internal set; }

        public CardService CardService { get; internal set; }

        public BankAccountService BankAccountService { get; internal set; }

        public ChargeService ChargeService { get; internal set; }

        private OpenpayHttpClient httpClient;

        public OpenpayAPI( string api_key, string merchant_id,bool production = false)
        {
            this.httpClient = new OpenpayHttpClient(api_key, merchant_id, production);
            CustomerService = new CustomerService(this.httpClient);
            CardService = new CardService(this.httpClient);
            BankAccountService = new BankAccountService(this.httpClient);
            ChargeService = new ChargeService(this.httpClient);
        }

        public bool Production {
            get
            {
                return this.httpClient.Production;
            }
            set
            {
                this.httpClient.Production = value;
            }
        }
    }
}
