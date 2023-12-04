using MassTransit;
using Model;

namespace PubConsumer.API
{
    public class CardService : ICardService
    {
        private readonly IBusControl _bus;

        public CardService(IBusControl bus)
        {
            _bus = bus;
        }

        public async Task SendCardTransferInformation(string queueName, Order order)
        {
            //var endpoint = await _bus.GetSendEndpoint(new Uri($"rabbitmq://localhost:5762/{queueName}"));
            var endpoint = await _bus.GetSendEndpoint(new Uri($"/*rabbitmq://*/10.100.72.111:5762/teller/{queueName}"));
            await endpoint.Send(order);
            // Console.WriteLine($"[Sent] Card transfer information to {queueName} from {platform}: {cardDetails}");
        }
    }
}
