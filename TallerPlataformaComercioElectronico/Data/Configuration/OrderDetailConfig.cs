using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Amount).HasPrecision(18, 2).HasDefaultValue(0);

            builder.HasOne(t => t.Order).WithMany(m => m.Detail).HasForeignKey(t => t.OrderId);
            builder.HasOne(t => t.Product).WithMany(m => m.Detail).HasForeignKey(t => t.ProductId);
        }
    }
}
