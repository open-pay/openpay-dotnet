using Openpay.Entities;

namespace Openpay
{
    public class MerchantService : OpenpayResourceService<Merchant, Merchant>, IMerchantService
    {

        public MerchantService(string api_key, string merchant_id, bool production = false)
            : base(api_key, merchant_id, production)
        {
            ResourceName = "";
        }

        internal MerchantService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "";
        }

        public Merchant Get()
        {
            return base.Get(null, null);
        }

    }
}
