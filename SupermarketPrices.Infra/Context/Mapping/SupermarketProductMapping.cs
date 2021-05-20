using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPrices.Domain.Entities;

namespace SupermarketPrices.Infra.Context.Mapping
{
    class SupermarketProductMapping : IEntityTypeConfiguration<SupermarketProduct>
    {
        public void Configure(EntityTypeBuilder<SupermarketProduct> builder)
        {

            builder.ToTable("SupermarketProduct");
            builder.HasKey(x => new { x.SupermarketId, x.ProductId });
            builder.Property(x => x.Date)
                .HasMaxLength(120)
                .HasColumnType("Date");
            builder.Property(x => x.Price)
                .HasMaxLength(120)
                .HasColumnType("decimal(18,2)");

            builder
                .HasOne<Supermarket>()
                .WithMany(p => p.SupermarketProduct)
                .HasForeignKey(pt => pt.SupermarketId);

            builder
                .HasOne<Product>()
                .WithMany(p => p.SupermarketProduct)
                .HasForeignKey(pt => pt.ProductId);
        }
    }
}
