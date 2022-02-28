using PrimeiroDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int id);

        Task<IEnumerable<Person>> GetAll();

        Task DeletePerson(Person person);

        Task UpdatePerson(Person person);

        Task<Person> CreatePerson(Person person);

    }
}
