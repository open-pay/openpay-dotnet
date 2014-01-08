using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openpay.Entities;
using Openpay.Entities.Request;

namespace Openpay
{
    public class ChargeService : ResourceService<ChargeRequest, Charge>
    {

        static readonly string merchant_path = "/charges";

        static readonly string customer_path = "/customers/{0}/charges";

        public ChargeService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {

        }

        internal ChargeService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {

        }

        public Charge Refund(string charge_id, string customer_id = null, string description = null, string order_id = null)
        {
            if (charge_id == null)
                throw new ArgumentNullException("charge_id cannot be null");
            string ep = GetEndPoint(customer_id, charge_id) + "/refund";
            RefundRequest request = new RefundRequest();
            request.Description = description;
            request.OrderId = order_id;
            return this.httpClient.Post<Charge>(ep, request);
        }

        public Charge Capture(string charge_id, string customer_id = null, Decimal amount = 0.0M)
        {
            if (charge_id == null)
                throw new ArgumentNullException("charge_id cannot be null");
            string ep = GetEndPoint(customer_id, charge_id) + "/capture";
            CaptureRequest request = new CaptureRequest();
            request.Amount = amount;
            return this.httpClient.Post<Charge>(ep, request);
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
