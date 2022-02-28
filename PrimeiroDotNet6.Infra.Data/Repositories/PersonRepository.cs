using PrimeiroDotNet6.Domain.Entities;
using PrimeiroDotNet6.Domain.Repositories;
using PrimeiroDotNet6.Infra.Data.Contex;
using System.Data.Entity;

namespace PrimeiroDotNet6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationContext _db;

        public PersonRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();

            return person;

        }

        public async Task DeletePerson(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _db.Peaple.ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _db.Peaple.FirstOrDefaultAsync( p => p.Id == id);  
        }

        public async Task UpdatePerson(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();   
        }
    }
}
