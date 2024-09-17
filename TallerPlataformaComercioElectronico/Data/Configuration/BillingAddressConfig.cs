using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class BillingAddressConfig : IEntityTypeConfiguration<BillingAddress>
    {
        public void Configure(EntityTypeBuilder<BillingAddress> builder)
        {
            builder.ToTable("BillingAddresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Street).HasMaxLength(100);
            builder.Property(x => x.PostalCode).HasMaxLength(10);

            builder.HasOne(t => t.City).WithMany(m => m.BillingAddresses).HasForeignKey(t => t.CityId);
        }
    }
}
