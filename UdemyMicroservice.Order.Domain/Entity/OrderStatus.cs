namespace UdemyMicroservice.Order.Domain.Entity
{
	public enum OrderStatus
	{
		WaitingForPayment = 1,
		Paid = 2,
		Cancel = 3,
	}
}
