using PrimeiroDotNet6.Domain.Entities;
using PrimeiroDotNet6.Domain.InterfacesRepositories;
using PrimeiroDotNet6.Infra.Data.Contex;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiroDotNet6.Infra.Data.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _db;

        public ProductRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _db.Add(product);
             await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProduct(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }
    }
}
