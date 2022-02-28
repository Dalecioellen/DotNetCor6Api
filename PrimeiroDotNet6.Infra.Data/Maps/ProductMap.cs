using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeiroDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Infra.Data.Maps
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

          builder.ToTable("Produto")
                .HasKey(x => x.Id);

            //mapenado classes com as suas tabelas
            builder.Property(x => x.Id)
                .HasColumnName("IdProduto")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("Nome");

            builder.Property(x => x.Price)
                .HasColumnName("Preco");

            builder.Property(x => x.CodErp)
                .HasColumnName("CodErp");

            //Realcionamento de um produto para várias compras

            builder.HasMany(x => x.Purchases)// varias compras de
                .WithOne(x => x.Product) // um mesmo produto 
                .HasForeignKey(x => x.ProductId); //tal que a chave será o ProductId

        }
    }
}
