using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openpay.Entities
{

    public class Transaction : OpenpayResourceObject
    {
        [JsonProperty(PropertyName = "creation_date")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public Decimal Amount { get; set; }

        [JsonProperty(PropertyName = "status")]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }

        [JsonProperty(PropertyName = "transaction_type")]
        public String TransactionType { get; set; }

        [JsonProperty(PropertyName = "operation_type")]
        public String OperationType { get; set; }

        [JsonProperty(PropertyName = "method")]
        public String Method { get; set; }

        [JsonProperty(PropertyName = "error_message")]
        public String ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "card")]
        public Card Card { get; set; }

        [JsonProperty(PropertyName = "bank_account")]
        public BankAccount BankAccount { get; set; }

        [JsonProperty(PropertyName = "authorization")]
        public String Authorization { get; set; }

        [JsonProperty(PropertyName = "order_id")]
        public String OrderId { get; set; }

        [JsonProperty(PropertyName = "customer_id")]
        public String CustomerId { get; set; }

        [JsonProperty(PropertyName = "conciliated")]
        public Boolean Conciliated { get; set; }

		[JsonProperty(PropertyName = "due_date")]
		public DateTime? DueDate { get; set; }

    }

    public class Refund : Transaction { }

    public class Charge : Transaction {

        [JsonProperty(PropertyName = "refund")]
        public Refund Refund { get; set; }

        [JsonProperty(PropertyName = "payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty(PropertyName = "card_points")]
        public CardPoints CardPoints { get; set; }

		[JsonProperty(PropertyName = "exchange_rate")]
		public ExchangeRate ExchangeRate { get; set; }

		[JsonProperty(PropertyName = "metadata")]
		public Dictionary<String, String> Metadata { set; get; }

		[JsonProperty(PropertyName = "customer")]
		public Customer Customer { get; set; }
    }

    public class Payout : Transaction { }

    public class Fee : Transaction { }

    public class Transfer : Transaction { }
}
