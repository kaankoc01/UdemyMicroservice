﻿using MassTransit;
using System.Text;

namespace UdemyMicroservice.Order.Domain.Entity
{
	public class Order : BaseEntity<Guid>
	{

		public string Code { get; set; } = null!;

		public DateTime Created { get; set; }

		public Guid BuyerId { get; set; }

		public OrderStatus Status { get; set; }

		public int AddressId { get; set; }

		public decimal TotalPrice { get; set; }

		public float? DiscountRate { get; set; }

		public Guid? PaymentId { get; set; }

		public List<OrderItem> OrderItems { get; set; } = new();

		public Address Address { get; set; } = null!;

		public static string GenerateCode()
		{
			var random = new Random();
			var orderCode = new StringBuilder(10);
			for (int i = 0; i < 10; i++)
			{
				orderCode.Append(random.Next(0, 10));
			}
			return orderCode.ToString();
		}
		public static Order CreateUnPaidOrder(Guid buyerId, float? discountRate, int addressId)
		{
			return new Order()
			{
				Id = NewId.NextGuid(),
				Code = GenerateCode(),
				Created = DateTime.Now,
				BuyerId = buyerId,
				Status = OrderStatus.WaitingForPayment,
				AddressId = addressId,
				DiscountRate = discountRate,
				TotalPrice = 0,
			};
		}
		public static Order CreateUnPaidOrder(Guid buyerId, float? discountRate)
		{
			return new Order()
			{
				Id = NewId.NextGuid(),
				Code = GenerateCode(),
				Created = DateTime.Now,
				BuyerId = buyerId,
				Status = OrderStatus.WaitingForPayment,
				DiscountRate = discountRate,
				TotalPrice = 0,
			};
		}
		public void AddOrderItem(Guid productId, string productName, decimal unitPrice)
		{
			var orderItem = new OrderItem();
			orderItem.SetItem(productId, productName, unitPrice);
			OrderItems.Add(orderItem);
			CalculateTotalPrice();
		}
		private void CalculateTotalPrice()
		{
			TotalPrice = OrderItems.Sum(x => x.UnitPrice);
			if (DiscountRate.HasValue)
			{
				TotalPrice = TotalPrice - (TotalPrice * (decimal)DiscountRate.Value / 100);
			}
		}
		public void ApplyDiscount(float discountPercentage)
		{
			if (discountPercentage < 0 || discountPercentage > 100)
				throw new ArgumentNullException("Discount percentage must be between 0 and 100");
			DiscountRate = discountPercentage;
			CalculateTotalPrice();
		}
		public void SetPaidStatus(Guid paymentId) { 
		
			Status= OrderStatus.Paid;
			this.PaymentId = paymentId;
		}
	}
}
