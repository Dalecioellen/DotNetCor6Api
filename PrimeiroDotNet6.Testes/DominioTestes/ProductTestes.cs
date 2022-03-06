using PrimeiroDotNet6.Domain.Entities;
using PrimeiroDotNet6.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PrimeiroDotNet6.Testes.DominioTestes
{
    public class ProductTestes
    {
        public ProductTestes()
        {
        }

        [Fact]
        public void Deve_Ser_Possivel_Criar_Um_Produto()
        {
            var produto = new Product(name: "Tênis", price: 1000, codErp: "01");

            Assert.NotNull(produto.Name);
            Assert.NotEmpty(produto.Name);
            Assert.NotNull(produto.CodErp);
            Assert.NotEmpty(produto.CodErp);
            Assert.NotEmpty(produto.Price.ToString());

        }

        [Fact]
        public void Nao_Deve_Ser_Possivel_Criar_Um_Produto_Sem_Nome()
        {

           var ex = Assert.Throws<DomainValidationException>(() => new Product(name: "", price: 1000, codErp: "01"));
            Assert.Equal("O nome é obrigatório e não pode ser vazio", ex.Message);

        }

        [Fact]
        public void Nao_Deve_Ser_Possivel_Criar_Um_Produto_Com_Preco_Menor_Ou_Igual_a_Zero()
        {

            var ex = Assert.Throws<DomainValidationException>(() => new Product(name: "Blusa", price: 0, codErp: "01"));
            Assert.Equal("O preço é obrigatório e deve ser maior do que 0", ex.Message);

        }

        [Fact]
        public void Nao_Deve_Ser_Possivel_Criar_Um_Produto_Sem_CodErp()
        {

            var ex = Assert.Throws<DomainValidationException>(() => new Product(name: "Blusa", price: 1000, codErp: ""));
            Assert.Equal("O Código Erp é obrigatório e deve ser informado", ex.Message);

        }
    }
}
