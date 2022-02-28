using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeiroDotNet6.Domain.Entities;


namespace PrimeiroDotNet6.Infra.Data.Maps
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
        }

        public void Configure(EntityTypeBuilder<Person> builder)
        {

            //mapemaneto dos objetos e das tabelas
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .HasColumnName("IdPessoa")
              .UseIdentityColumn(); //será a coluna que de registros dos Ids

            builder.Property(x => x.Document)
                .HasColumnName("Documento");

            builder.Property(x => x.Name)
                .HasColumnName("Nome");

            builder.Property(x => x.Phone)
                .HasColumnName("Telefone");

            // relacionamento entre as tabelas e objetos

            builder.HasMany(x => x.Purchases) // relacionamento  varias compras
                .WithOne(x => x.Person) // para uma pessoa
                .HasForeignKey(x => x.PersonId); //tal que a chave é o PersonId, ou seja o Id da pessoa será registrado na coluna pessoaId(PersonId) na tabela compras(Purchases)
        }
    }
}
