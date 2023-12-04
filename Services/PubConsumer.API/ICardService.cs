using Model;

namespace PubConsumer.API
{
    public interface ICardService
    {
        Task SendCardTransferInformation(string queueName, Order order);
    }
}