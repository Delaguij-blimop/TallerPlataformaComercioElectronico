using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Street).HasMaxLength(100);
            builder.Property(x => x.PostalCode).HasMaxLength(10);

            builder.HasOne(t => t.City).WithMany(m => m.BillingAddresses).HasForeignKey(t => t.CityId);
        }
    }
}
