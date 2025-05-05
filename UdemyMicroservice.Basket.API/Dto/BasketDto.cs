using System.Text.Json.Serialization;

namespace UdemyMicroservice.Basket.API.Dto
{
    public record BasketDto
    {
        public List<BasketItemDto> Items { get; set; } = new();

		public float? DiscountRate { get; set; }
		public string? Coupon { get; set; }

		[JsonIgnore] public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
		public decimal TotalPrice => Items.Sum(x => x.Price);
		
		public decimal? TotalPriceWithAppliedDiscount
		{
			get
			{
				if (!IsApplyDiscount)
					return null;
				return Items.Sum(x => x.PriceByApplyDiscountRate); ;
			}
		}

		public BasketDto(List<BasketItemDto> items)
        {
            Items = items;
        }
        public BasketDto()
        {
        }

    }
}
