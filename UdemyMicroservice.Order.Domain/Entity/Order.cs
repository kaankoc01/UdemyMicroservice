namespace UdemyMicroservice.Order.Domain.Entity
{
	public class Order
	{
		public string Code { get; set; } = null!;

		public DateTime Created { get; set; }

		public Guid BuyerId { get; set; }

		public OrderStatus Status { get; set; }

		public int AddressId { get; set; }

		public decimal TotalPrice { get; set; }

		public Guid PaymentId { get; set; }

	}

	public enum OrderStatus
	{
		WaitingForPayment = 1,
		Paid = 2,
		Cancel = 3,
	}
}
