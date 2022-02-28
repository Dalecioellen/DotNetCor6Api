using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeiroDotNet6.Domain.Entities;


namespace PrimeiroDotNet6.Infra.Data.Maps
{
    internal class PurchasesMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("IdCompra")
                .UseIdentityColumn();

            builder.Property(p => p.PersonId)
                .HasColumnName("IdPessoa");

            builder.Property(p => p.ProductId)
                .HasColumnName("IdProduto");

            builder.Property(p => p.Date)
             .HasColumnName("DataCompra");

            builder.HasOne( p => p.Product)
                .WithMany(p => p.Purchases)
                .HasForeignKey(p => p.ProductId);

            builder.HasOne(p => p.Person)
                .WithMany(p => p.Purchases)
                .HasForeignKey(p => p.PersonId);
        }
    }
}
