using Confluent.Kafka;
using Shared;
using System.Text.Json;

namespace ApacheKafka.ProductApi.ProductServices
{
    public class ProductService(IProducer<Null, string> producer ) : IProductService
    {
        private List<Product> Products = [];
        public async Task AddProduct(Product product)
        {
            Products.Add(product);
            var result = await producer.ProduceAsync("add-product-topic",
                new Message<Null, string> { Value = JsonSerializer.Serialize(product) });

            if (result.Status != PersistenceStatus.Persisted)
            {
                //get last product
                var lastProduct = Products.Last();
                //remove the last product
                Products.Remove(lastProduct);
            }
        }

        public async Task DeleteProduct(int id)
        {
            Products.Remove(Products.FirstOrDefault(x=>x.Id == id)!);
            await producer.ProduceAsync("delete-product-topic", new Message<Null, string> { Value = id.ToString() });
        }
    }
}
