using PrimeiroDotNet6.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Domain.Entities
{
    public sealed class Product
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        public decimal Price { get; private set; }

        public string CodErp { get; private set; }

        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name, decimal price, string codErp) // construtor pra post
        {
            validation(name, price, codErp);
        }

        public Product(string name, decimal price, string codErp, int id)// construtor pra put
        {
            DomainValidationException.TemErro(Id < 0, "O Id é obrigatório e deve ser maior do que 0");
            Id = id;
            validation(name, price, codErp);
        }


        private void validation(string name, decimal price, string codErp)
        {
            DomainValidationException.TemErro(string.IsNullOrEmpty(name), "O nome é obrigatório e não pode ser vazio");

            DomainValidationException.TemErro(price < 1, "O preço é obrigatório e deve ser maior do que 0");

            DomainValidationException.TemErro(string.IsNullOrEmpty(codErp), "O Código Erp é obrigatório e deve ser informado");

            Name = name;
            Price = price;
            CodErp = codErp;
        }
    }
}
