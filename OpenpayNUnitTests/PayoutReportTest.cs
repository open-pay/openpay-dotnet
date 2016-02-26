using NUnit.Framework;
using System;
using Openpay;
using Openpay.Entities;
using Openpay.Entities.Request;
using System.Collections.Generic;

namespace OpenpayNUnitTests
{
	[TestFixture ()]
	public class PayoutReportTest
	{
		[Test ()]
		public void TestReport_ReportSummary ()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			PayoutSummary payoutSummary = openpayAPI.PayoutReportService.Get("tro7nlbckqqdecep7par");
			Assert.AreEqual (payoutSummary.In, new Decimal (87969.1));
			Assert.AreEqual (payoutSummary.Out, new Decimal (8767.23));
		}

		[Test ()]
		public void TestReport_ReportDetails_In ()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			PayoutReportDetailSearchParams search = new PayoutReportDetailSearchParams("in");
			List<Transaction> detail = openpayAPI.PayoutReportService.Detail("tro7nlbckqqdecep7par", search);
			Assert.AreEqual (10, detail.Count);
			Assert.AreEqual ("trhentoxhaqy0fnhan1x", detail[0].Id);
			Assert.AreEqual ("tryjharmg7izrestvsnl", detail[1].Id);
			Assert.AreEqual ("trfqtjhc4lxokucculbg", detail[2].Id);
			Assert.AreEqual ("trvpuas96jez8rlhvbps", detail[3].Id);
			Assert.AreEqual ("trdjduxpcbtgfkhritda", detail[4].Id);
			Assert.AreEqual ("trkbvruzglnpvjsaei3c", detail[5].Id);
			Assert.AreEqual ("trziivcvebq0yjkhxtqq", detail[6].Id);
			Assert.AreEqual ("trj9u4wdakoeh9i03n8x", detail[7].Id);
			Assert.AreEqual ("trlnmrvh8agjht6wmkh5", detail[8].Id);
			Assert.AreEqual ("trfvopnmzdljgaehvbcs", detail[9].Id);
			foreach (Transaction t in detail) {
				Assert.IsNotNull (t.Amount);
				Assert.Greater (t.Amount, 0);
			}
		}

		[Test ()]
		public void TestReport_ReportDetails_In_Pagination_Offset ()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			PayoutReportDetailSearchParams search = new PayoutReportDetailSearchParams("in");
			search.Limit = 5;
			search.Offset = 3;
			List<Transaction> detail = openpayAPI.PayoutReportService.Detail("tro7nlbckqqdecep7par", search);
			Assert.AreEqual (5, detail.Count);
			Assert.AreEqual ("trvpuas96jez8rlhvbps", detail[0].Id);
			Assert.AreEqual ("trdjduxpcbtgfkhritda", detail[1].Id);
			Assert.AreEqual ("trkbvruzglnpvjsaei3c", detail[2].Id);
			Assert.AreEqual ("trziivcvebq0yjkhxtqq", detail[3].Id);
			Assert.AreEqual ("trj9u4wdakoeh9i03n8x", detail[4].Id);
			foreach (Transaction t in detail) {
				Assert.IsNotNull (t.Amount);
				Assert.Greater (t.Amount, 0);
			}
		}

		[Test ()]
		public void TestReport_ReportDetails_Out ()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			PayoutReportDetailSearchParams search = new PayoutReportDetailSearchParams("out");
			List<Transaction> detail = openpayAPI.PayoutReportService.Detail("tro7nlbckqqdecep7par", search);
			Assert.AreEqual (10, detail.Count);
			Assert.AreEqual ("trlzz0ekx6nw3t5cy5qp", detail[0].Id);
			Assert.AreEqual ("trugdjdkrdgmokygcnhb", detail[1].Id);
			Assert.AreEqual ("tr9zmcxmfjh9hzhq4wf7", detail[2].Id);
			Assert.AreEqual ("trszooeqyvubp64otgqw", detail[3].Id);
			Assert.AreEqual ("trlsuuwpzxrddqvfbpnq", detail[4].Id);
			Assert.AreEqual ("trs2yv84jssyouuav6pw", detail[5].Id);
			Assert.AreEqual ("triwvjokvz7xn6zqxfhm", detail[6].Id);
			Assert.AreEqual ("trbkqxnihitgylphbtx6", detail[7].Id);
			Assert.AreEqual ("tr0wlb06npukqm9femuk", detail[8].Id);
			Assert.AreEqual ("trqykjamb4vfoozt2o37", detail[9].Id);
			foreach (Transaction t in detail) {
				Assert.IsNotNull (t.Amount);
				Assert.Greater (t.Amount, 0);
			}
		}

		[Test ()]
		public void TestReport_ReportDetails_ChargedAdjustments ()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			PayoutReportDetailSearchParams search = new PayoutReportDetailSearchParams("charged_adjustments");
			List<Transaction> detail = openpayAPI.PayoutReportService.Detail("tro7nlbckqqdecep7par", search);
			Assert.AreEqual (0, detail.Count);
		}

		[Test ()]
		public void TestReport_ReportDetails_RefundedAdjustments ()
		{
			OpenpayAPI openpayAPI = new OpenpayAPI(Constants.API_KEY, Constants.MERCHANT_ID);
			PayoutReportDetailSearchParams search = new PayoutReportDetailSearchParams("refunded_adjustments");
			List<Transaction> detail = openpayAPI.PayoutReportService.Detail("tro7nlbckqqdecep7par", search);
			Assert.AreEqual (1, detail.Count);
			Assert.AreEqual ("trnkwmfcjb6yqkntlbg1", detail[0].Id);
			foreach (Transaction t in detail) {
				Assert.IsNotNull (t.Amount);
				Assert.Greater (t.Amount, 0);
			}
		}
	}
}

