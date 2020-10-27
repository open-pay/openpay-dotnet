namespace Openpay
{
    public interface IOpenpayAPI
    {
        IBankAccountService BankAccountService { get; }
        ICardService CardService { get; }
        IChargeService ChargeService { get; }
        ICustomerService CustomerService { get; }
        IFeeService FeeService { get; }
        IMerchantService MerchantService { get; set; }
        IOpenpayFeesService OpenpayFeesService { get; }
        IPayoutReportService PayoutReportService { get; }
        IPayoutService PayoutService { get; }
        IPlanService PlanService { get; }
        bool Production { get; set; }
        ISubscriptionService SubscriptionService { get; }
        ITransferService TransferService { get; }
        IWebhookService WebhooksService { get; set; }
    }
}