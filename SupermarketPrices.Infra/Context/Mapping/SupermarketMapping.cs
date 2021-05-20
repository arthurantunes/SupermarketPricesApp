using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPrices.Domain.Entities;

namespace SupermarketPrices.Infra.Context.Mapping
{
    class SupermarketMapping : IEntityTypeConfiguration<Supermarket>
    {
        public void Configure(EntityTypeBuilder<Supermarket> builder)
        {

            builder.ToTable("Supermarket");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");

        }
    }
}
