using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities.Request
{
	public class PayoutReportDetailSearchParams
    {
		public PayoutReportDetailSearchParams(String _DetailType) {
            Offset = 0;
            Limit = 10;
			DetailType = _DetailType;
        }

        public int Offset { get; set; }

        public int Limit { get; set; }

        public String DetailType { get; set; }

    }
}
