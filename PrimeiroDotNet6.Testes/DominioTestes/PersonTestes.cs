using PrimeiroDotNet6.Domain.Entities;
using PrimeiroDotNet6.Domain.Validation;
using System;
using Xunit;

namespace PrimeiroDotNet6.Testes
{
    public class PersonTestes
    {

        [Fact]
        public void Deve_Ser_Possivel_Criar_Uma_Pessoa_Com_Os_Dados_Preenchidos()
        {
            Person pessoa = new Person(name: "Maria Bonita", document: "2365236", phone: "123456789");

            Assert.NotNull(pessoa.Name);
            Assert.NotNull(pessoa.Document);
            Assert.NotNull(pessoa.Phone);
            Assert.NotEmpty(pessoa.Name);
            Assert.NotEmpty(pessoa.Document);
            Assert.NotEmpty(pessoa.Phone);
        }

        [Fact]
        public void Nao_Deve_Ser_Possivel_Criar_Um_Pessoa_Com_O_Nome_Null_Ou_Vazio()
        {
           
            var ex = Assert.Throws<DomainValidationException>(() =>  new Person("", "22225568", "2345678"));
            Assert.Equal("O nome é obrigatório e não pode ser vazio", ex.Message);
        }

        [Fact]
        public void Nao_Deve_Ser_Possivel_Criar_Um_Pessoa_Com_O_Documento_Null_Ou_Vazio()
        {

            var ex = Assert.Throws<DomainValidationException>(() => new Person("Ellen", "", "2345678"));
            Assert.Equal("O documento é obrigatório e não pode ser vazio", ex.Message);
        }

        [Fact]
        public void Nao_Deve_Ser_Possivel_Criar_Um_Pessoa_Com_O_Telefone_Null_Ou_Vazio()
        {

            var ex = Assert.Throws<DomainValidationException>(() => new Person("Ellen", "22225568", ""));
            Assert.Equal("O telefone é obrigatório e não pode ser vazio", ex.Message);
        }

    }
}