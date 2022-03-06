using PrimeiroDotNet6.Domain.Validation;

namespace PrimeiroDotNet6.Domain.Entities
{
    public class Purchase
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int PersonId { get; set; }

        public DateTime? Date { get; set; }

        public Person Person { get; set; }

        public Product Product { get; set; }

        public Purchase(int productId, int personId, DateTime? date)
        {
            validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
            DomainValidationException.TemErro(id < 0, "O Id é obrigatório e não pode ser vazio");
            Id = id;
            validation(productId, personId, date);
        }

        private void validation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.TemErro(productId == 0, "O ProductId deve ser maior do que 0");

            DomainValidationException.TemErro(personId <= 0, "O PersonId deve ser maior do que 0");

            DomainValidationException.TemErro(date == null, "A data é obrigatória e deve ser informada");

            ProductId = productId;
            PersonId = personId;
            Date = date;
        }

    }
}
