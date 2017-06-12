using System;

namespace Openpay.Entities
{
	public enum TransactionStatus
	{
		IN_PROGRESS,
		COMPLETED,
		REFUNDED,
		CHARGEBACK_PENDING,
		CHARGEBACK_ACCEPTED,
		CHARGEBACK_ADJUSTMENT,
		CHARGE_PENDING,
		CANCELLED,
		FAILED
	}
}