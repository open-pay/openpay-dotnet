using Openpay.Entities;
using Openpay.Entities.Request;
using Openpay.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay
{
	public class OpenpayFeesService
	{
		internal OpenpayHttpClient httpClient;

		public OpenpayFeesService(string api_key, string merchant_id, Countries country = Countries.MX, bool production = false)
		{
			this.httpClient = new OpenpayHttpClient(api_key, merchant_id, country, production);
		}

		internal OpenpayFeesService(OpenpayHttpClient opHttpClient)
		{
			this.httpClient = opHttpClient;
		}

		internal String GetEndPoint()
		{
			return "/reports/fees";
		}

		public OpenpayFeesSummary Summary(int year, int month)
		{
			string url = GetEndPoint();
			url = url + BuildParams(year, month, null, null);
			return this.httpClient.Get<OpenpayFeesSummary>(url);
		}

		public List<Transaction> Details(int year, int month, string fee_type, PaginationParams paginationParams)
		{
			string url = GetEndPoint() + "/detail";
			url = url + BuildParams(year, month, fee_type, paginationParams);
			return this.httpClient.Get<List<Transaction>>(url);
		}

		internal string BuildParams(int year, int month, string fee_type, PaginationParams paginationParams)
		{
			string url_params = string.Empty;
			url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "year", year.ToString());
			url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "month", month.ToString());
			if (fee_type != null) {
				url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "fee_type", fee_type);
			}
			if (paginationParams != null)
			{
				if (paginationParams.Offset < 0)
					throw new ArgumentOutOfRangeException("offset");
				if (paginationParams.Limit < 1 || paginationParams.Limit > 100)
					throw new ArgumentOutOfRangeException("limit");

				url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "limit", paginationParams.Limit.ToString());
				url_params = ParameterBuilder.ApplyParameterToUrl(url_params, "offset", paginationParams.Offset.ToString());
			}
			return url_params;
		}
	}
}

