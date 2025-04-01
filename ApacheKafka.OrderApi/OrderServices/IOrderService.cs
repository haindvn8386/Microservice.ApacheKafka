using Shared;

namespace ApacheKafka.OrderApi.OrderServices
{
    public interface IOrderService
    {
        Task StartConsumingService();
        void AddOrder(Order order);
        List<Product> GetProducts();
        List<OrderSummary> GetOrdersSummary();
    }
}
