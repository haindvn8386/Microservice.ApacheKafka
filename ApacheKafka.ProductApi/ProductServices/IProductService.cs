using Shared;

namespace ApacheKafka.ProductApi.ProductServices
{
    public interface IProductService
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int id);
    }
}
