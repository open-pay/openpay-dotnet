using Openpay.Entities;

namespace Openpay
{
    public class TokenService : OpenpayResourceService<TokenRequest, Token>
    {

        public TokenService(string api_key, string merchant_id, string publicIp, Countries country, bool production = false)
            : base(api_key, merchant_id,publicIp, country, production)
        {
            ResourceName = "tokens";
        }

        internal TokenService(OpenpayHttpClient opHttpClient)
            : base(opHttpClient)
        {
            ResourceName = "tokens";
        }

        public Token Create(TokenRequest token_request)
        {
            
            return base.Create(null, token_request);
        }

        public Token Get(string token_id)
        {
            return base.Get(null, token_id);
        }
    }
}
