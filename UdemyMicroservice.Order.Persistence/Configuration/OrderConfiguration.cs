using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UdemyMicroservice.Order.Persistence.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entity.Order>
	{
		public void Configure(EntityTypeBuilder<Domain.Entity.Order> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever();
			builder.Property(x => x.Code).IsRequired().HasMaxLength(10);
			builder.Property(x => x.Created).IsRequired();
			builder.Property(x => x.BuyerId).IsRequired();
			builder.Property(x => x.Status).IsRequired();
			builder.Property(x => x.AddressId).IsRequired();
			builder.Property(x => x.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
			builder.Property(x => x.DiscountRate).HasColumnType("float");


			builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);

			builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);
		}
	}
}
