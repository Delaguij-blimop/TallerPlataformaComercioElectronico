using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CardNumber).HasMaxLength(20);
            builder.Property(x => x.CardHolderName).HasMaxLength(100);
            builder.Property(x => x.CVV).HasMaxLength(10);
            builder.Property(x => x.Amount).HasPrecision(18, 2).HasDefaultValue(0);

            builder.HasOne(t => t.Order).WithMany(m => m.Payments).HasForeignKey(t => t.OrderId);
            builder.HasOne(t => t.PaymentType).WithMany(m => m.Payments).HasForeignKey(t => t.PaymentTypeId);
        }
    }
}
