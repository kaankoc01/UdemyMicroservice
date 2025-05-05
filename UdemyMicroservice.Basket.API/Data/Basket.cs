using System.Text.Json.Serialization;

namespace UdemyMicroservice.Basket.API.Data
{
	public class Basket
	{
		public Basket(Guid userId, List<BasketItem> items)
		{
			UserId = userId;
			Items = items;
		}
		public Basket()
		{

		}
		public Guid UserId { get; init; }
		public List<BasketItem> Items { get; set; } = new();
		public float? DiscountRate { get; set; }
		public string? Coupon { get; set; }
		[JsonIgnore]
		public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
		
		public void ApplyNewDiscount(string coupon, float discountRate)
		{
			Coupon = coupon;
			DiscountRate = discountRate;
			foreach (var basket in Items)
			{
				basket.PriceByApplyDiscountRate = basket.Price * (decimal)(1 - DiscountRate);
			}
		}
		public void ApplyAvailableDiscount()
		{
			if (!IsApplyDiscount)
			{
				return;
			}
			foreach (var basket in Items)
			{
				basket.PriceByApplyDiscountRate = basket.Price * (decimal)(1 - DiscountRate!);
			}
		}
		public void ClearDiscount()
		{
			Coupon = null;
			DiscountRate = null;
			foreach (var basket in Items)
			{
				basket.PriceByApplyDiscountRate = null;
			}
		}
	}
}
