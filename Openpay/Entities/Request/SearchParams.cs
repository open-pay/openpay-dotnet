using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities.Request
{
    public class SearchParams
    {
        public SearchParams() {
            Offset = 0;
            Limit = 10;
        }

        public int Offset { get; set; }

        public int Limit { get; set; }

        public Decimal Amount { get; set; }

        public Decimal AmountGte { get; set; }

        public Decimal AmountLte { get; set; }

        public DateTime Creation { get; set; }

        public DateTime CreationGte { get; set; }

        public DateTime CreationLte { get; set; }

		public String OrderId { set; get; }
        
        public String StartDate { set; get; }
        
        public String EndDate { set; get; }

		public TransactionStatus? Status { set; get; }

        public void Between(DateTime start, DateTime end)
        {
            CreationGte = start;
            CreationLte = end;
        }

    }
}
