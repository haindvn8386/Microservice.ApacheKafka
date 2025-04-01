using Confluent.Kafka;
using Shared;
using System.Text.Json;

namespace ApacheKafka.OrderApi.OrderServices
{
    public class OrderService(IConsumer<Null,string> consumer) : IOrderService
    {
        private const string AddProudctTopic = "add-product-topic";
        private const string DeleteProductTopic = "delete-product-topic";
        public List<Product> Products = [];
        public List<Order> Orders = [];


        public void AddOrder(Order order) => Orders.Add(order);

        public List<OrderSummary> GetOrdersSummary()
        {
            var orderSummary = new List<OrderSummary>();

            foreach (var order in Orders)
            {
                orderSummary.Add(new OrderSummary(){
                    OrderId = order.Id,
                    ProductId = order.ProductId,
                    ProductName = Products.FirstOrDefault(x=>x.Id==order.ProductId)!.Name,
                    ProductPrice = Products.FirstOrDefault(x => x.Id == order.ProductId)!.Price,
                    OrderedQuantity = order.Quantity
                });
            }
            return orderSummary;
        }

        public List<Product> GetProducts() => Products;

        public async Task StartConsumingService()
        {
            await Task.Delay(10);
            consumer.Subscribe([AddProudctTopic, DeleteProductTopic]);
            while (true)
            {
                var response = consumer.Consume();
                if (!string.IsNullOrEmpty(response.Message.Value))
                {
                    //check if topic == adn product topic
                    if (response.Topic == AddProudctTopic)
                    {
                        var product = JsonSerializer.Deserialize<Product>(response.Message.Value);
                        Products.Add(product!);
                    }
                    else
                    {
                        Products.Remove(Products.FirstOrDefault(x => x.Id == int.Parse(response.Message.Value))!);
                    }

                    ConsoleProduct();
                }
            }
        }

        private void ConsoleProduct()
        {
            Console.Clear();
            foreach (var item in Products)
            {
                Console.WriteLine($"item {item.Id} , Name: {item.Name}, Price :{item.Price} ");
            }
        }

    }
}
