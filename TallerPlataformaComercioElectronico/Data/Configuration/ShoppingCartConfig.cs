using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCarts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserName).HasMaxLength(256);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasOne(t => t.Product).WithMany(m => m.Carts).HasForeignKey(t => t.ProductId);
            builder.HasOne(t => t.Order).WithMany(m => m.Carts).HasForeignKey(t => t.OrderId);
        }
    }
}
