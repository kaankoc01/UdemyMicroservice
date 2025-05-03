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

        public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
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
        public void ApplyNewDiscount(string coupon, float discountRate)
        {
            Coupon = coupon;
            DiscountRate = discountRate;
            foreach (var basket in Items)
            {
                basket.PriceByApplyDiscountRate = basket.Price * (decimal)(1 - discountRate);
            }
        }
        public void ApplyAvailableDiscount()
        {
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
