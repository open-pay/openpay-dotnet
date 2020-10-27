namespace Openpay
{
    public class OpenpayAPI : IOpenpayAPI
    {
        public ICustomerService CustomerService { get; internal set; }

        public ICardService CardService { get; internal set; }

        public IBankAccountService BankAccountService { get; internal set; }

        public IChargeService ChargeService { get; internal set; }

        public IPayoutReportService PayoutReportService { get; internal set; }

        public ITransferService TransferService { get; internal set; }

        public IPayoutService PayoutService { get; internal set; }

        public IFeeService FeeService { get; internal set; }

        public IPlanService PlanService { get; internal set; }

        public ISubscriptionService SubscriptionService { get; internal set; }

        public IOpenpayFeesService OpenpayFeesService { get; internal set; }

        public IWebhookService WebhooksService { get; set; }

        public IMerchantService MerchantService { get; set; }

        private readonly OpenpayHttpClient httpClient;

        public OpenpayAPI(string api_key, string merchant_id, bool production = false)
        {
            this.httpClient = new OpenpayHttpClient(api_key, merchant_id, production);
            CustomerService = new CustomerService(this.httpClient);
            CardService = new CardService(this.httpClient);
            BankAccountService = new BankAccountService(this.httpClient);
            ChargeService = new ChargeService(this.httpClient);
            PayoutService = new PayoutService(this.httpClient);
            TransferService = new TransferService(this.httpClient);
            FeeService = new FeeService(this.httpClient);
            PlanService = new PlanService(this.httpClient);
            SubscriptionService = new SubscriptionService(this.httpClient);
            OpenpayFeesService = new OpenpayFeesService(this.httpClient);
            WebhooksService = new WebhookService(this.httpClient);
            PayoutReportService = new PayoutReportService(this.httpClient);
            MerchantService = new MerchantService(this.httpClient);
        }

        public bool Production
        {
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
