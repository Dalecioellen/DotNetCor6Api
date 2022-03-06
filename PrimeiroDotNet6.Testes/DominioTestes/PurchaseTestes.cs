
using PrimeiroDotNet6.Domain.Entities;
using PrimeiroDotNet6.Domain.Validation;
using System;
using Xunit;

namespace PrimeiroDotNet6.Testes.DominioTestes
{
    public class PurchaseTestes
    {
        public PurchaseTestes()
        {
        }

        [Fact]

        public void Deve_Ser_Possivel_Criar_Uma_Compra()
        {
            var data = DateTime.Now;
            var compras = new Purchase(personId: 123, productId: 456, date: data);
            Assert.NotEmpty(compras.PersonId.ToString());
            Assert.NotEmpty(compras.ProductId.ToString());
            Assert.Equal(data, compras.Date);
        }

        [Fact]

        public void Nao_Deve_Ser_Possivel_Criar_Uma_Compra_Sem_PersonId()
        {
            var data = DateTime.Now;           
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(personId: 0, productId: 456, date: data));
            Assert.Equal("O PersonId deve ser maior do que 0", ex.Message);
        }

        [Fact]

        public void Nao_Deve_Ser_Possivel_Criar_Uma_Compra_Sem_ProductId()
        {
            var data = DateTime.Now;
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(personId: 0, productId: 0, date: data));
            Assert.Equal("O ProductId deve ser maior do que 0", ex.Message);
        }

        [Fact]

        public void Nao_Deve_Ser_Possivel_Criar_Uma_Compra_Sem_Date()
        {
           
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(personId: 2, productId: 456, date: null));
            Assert.Equal("A data é obrigatória e deve ser informada", ex.Message);
        }
    }
}
