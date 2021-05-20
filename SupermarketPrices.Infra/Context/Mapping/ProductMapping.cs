using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPrices.Domain.Entities;

namespace SupermarketPrices.Infra.Context.Mapping
{
    class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");
            builder.Property(x => x.Description)
                .HasMaxLength(120)
                .HasColumnType("text");
            builder.Property(x => x.EAN)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");
            builder.Property(x => x.SKU)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");
            builder.Property(x => x.Brand)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");

        }
    }
}
