using MassTransit;
using Rabbit.Consumer.DTOs.Consumer;
using Rabbit.Producer.Interfaces.Producer;

namespace Rabbit.Producer.Producer
{
    public class PixProducer : IPixProducer
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PixProducer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Producer(PixTransfer pixProducerRequest)
        {
            try
            {
                await _publishEndpoint.Publish(pixProducerRequest);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
