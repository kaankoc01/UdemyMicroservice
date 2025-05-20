using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyMicroservice.Order.Domain.Entity;

namespace UdemyMicroservice.Order.Persistence.Configuration
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.ProductId).IsRequired();
			builder.Property(x => x.ProductName).IsRequired().HasMaxLength(200);
		
			builder.Property(x => x.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");

		}
	}
}
