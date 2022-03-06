using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Application.DTOS.Validations
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {

            RuleFor(x => x.Name).NotNull()
              .NotEmpty()
                .WithMessage("O nome é obrigatório e não pode ser vazio");
            RuleFor(x => x.Document).NotNull()
              .NotEmpty()
              .WithMessage("O Documento é obrigatório e não pode ser vazio");

            RuleFor(x => x.Phone).NotNull()
               .NotEmpty()
               .WithMessage("O telefone é obrigatório e não pode ser vazio");
        }
    }
}
