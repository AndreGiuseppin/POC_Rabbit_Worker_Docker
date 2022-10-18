
using Rabbit.Consumer.DTOs.Consumer;

namespace Rabbit.Producer.Interfaces.Producer
{
    public interface IPixProducer
    {
        Task Producer(PixTransfer pixProducerRequest);
    }
}
