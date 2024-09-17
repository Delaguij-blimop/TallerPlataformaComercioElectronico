using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Price).HasPrecision(18, 2).HasDefaultValue(0);
            builder.Property(x => x.ImagePath).HasMaxLength(250);
            builder.Property(x => x.RegisterDate).HasDefaultValueSql("getutcdate()");

            builder.HasOne(t => t.Brand).WithMany(m => m.Products).HasForeignKey(t => t.BrandId);
            builder.HasOne(t => t.Category).WithMany(m => m.Products).HasForeignKey(t => t.CategoryId);
        }
    }
}
