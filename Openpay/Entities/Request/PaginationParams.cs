using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities.Request
{
	public class PaginationParams
	{
		public PaginationParams() {
			Offset = 0;
			Limit = 10;
		}

		public int Offset { get; set; }

		public int Limit { get; set; }

	}
}


