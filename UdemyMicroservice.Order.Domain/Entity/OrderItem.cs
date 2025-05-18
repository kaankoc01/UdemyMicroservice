namespace UdemyMicroservice.Order.Domain.Entity
{
	// anemic model => rich domainmodel
    public class OrderItem : BaseEntity<int>
    {
		public Guid ProductId { get; set; }
		public string ProductName { get; set; } = default!;
		public decimal UnitPrice { get; set; }

		public void SetItem(Guid productId, string productName, decimal unitPrice)
		{
			if (string.IsNullOrEmpty(ProductName))
			{
				throw new ArgumentNullException("ProductName cannot be empty.");
			}
			if (UnitPrice <= 0 )
			{
				throw new ArgumentNullException("UnitPrice cannot be less than or equal to zero.");
			}
			ProductId = productId;
			ProductName = productName;
			UnitPrice = unitPrice;

		}
		public void UpdatePrice(decimal newPrice)
		{
			if (newPrice <= 0)
			{
				throw new ArgumentNullException("UnitPrice cannot be less than or equal to zero.");
			}
			this.UnitPrice = newPrice;
		}
		public void ApplyDiscount(double discountPercentage)
		{
			if (discountPercentage < 0 || discountPercentage > 100)
			{
				throw new ArgumentNullException("Discount percentage must be between 0 and 100.");
			}
			this.UnitPrice = this.UnitPrice - (this.UnitPrice * (decimal)discountPercentage / 100);
		}
		public bool IsSameItem(OrderItem otherItem)
		{
			return this.ProductId == otherItem.ProductId;
		}


	}
}
