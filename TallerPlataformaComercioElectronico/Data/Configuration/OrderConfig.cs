using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TotalAmount).HasPrecision(18, 2).HasDefaultValue(0);
            builder.Property(x => x.Date).HasDefaultValueSql("getutcdate()");

            builder.HasOne(t => t.Currency).WithMany(m => m.Orders).HasForeignKey(t => t.CurrencyId);
        }
    }
}
