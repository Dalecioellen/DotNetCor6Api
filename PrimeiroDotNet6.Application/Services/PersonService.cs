using AutoMapper;
using PrimeiroDotNet6.Application.DTOS.Validations;
using PrimeiroDotNet6.Application.Services.Interfaces;
using PrimeiroDotNet6.Domain.Entities;
using PrimeiroDotNet6.Domain.Repositories;

namespace PrimeiroDotNet6.Application.Services
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultServices<PersonDto>> Create(PersonDto personDto)
        {

            if (personDto == null)
            {
                return ResultServices.Fail<PersonDto>(messege: "Objeto deve ser informado");
            }

            var result = new PersonDtoValidator().Validate(personDto);
            if (!result.IsValid)
            {
                return ResultServices.RequestError<PersonDto>("", result);
            }

            var person = _mapper.Map<Person>(personDto);
            var data = await _personRepository.CreatePerson(person);

            return ResultServices.Ok(_mapper.Map<PersonDto>(data));

        }
    }
}
