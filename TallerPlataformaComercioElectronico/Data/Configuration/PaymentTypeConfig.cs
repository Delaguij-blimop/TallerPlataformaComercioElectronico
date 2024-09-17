﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Data.Configuration
{
    public class PaymentTypeConfig : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("PaymentTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.RegisterDate).HasDefaultValueSql("getutcdate()");
        }
    }
}
