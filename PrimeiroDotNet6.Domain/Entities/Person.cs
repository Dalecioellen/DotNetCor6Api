using PrimeiroDotNet6.Domain.Validation;
using System.Collections.Generic;

namespace PrimeiroDotNet6.Domain.Entities
{
   public sealed class Person // sealed garante que ninguem herde dessa classe
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public ICollection <Purchase> Purchases{ get; set; }


        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.TemErro(id < 0, "O Id deve ser maior do que 0");
            Id = id;
            Validation(name, document, phone);

        }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.TemErro(string.IsNullOrEmpty(name), "O nome é obrigatório e não pode ser vazio");

            DomainValidationException.TemErro(string.IsNullOrEmpty(document), "O documento é obrigatório não pode ser vazio");

            DomainValidationException.TemErro(string.IsNullOrEmpty(phone), "O telefone é obrigatório não pode ser vazio");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
