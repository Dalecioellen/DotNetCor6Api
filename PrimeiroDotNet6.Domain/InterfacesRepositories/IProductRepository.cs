using PrimeiroDotNet6.Domain.Entities;


namespace PrimeiroDotNet6.Domain.InterfacesRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);

        Task<IEnumerable<Product>> GetAll();

        Task DeleteProduct(Product product);

        Task UpdateProduct(Product product);

        Task<Product> CreateProduct(Product product);

    }
}
