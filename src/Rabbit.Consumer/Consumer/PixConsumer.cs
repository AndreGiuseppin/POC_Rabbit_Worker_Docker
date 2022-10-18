using MassTransit;
using Rabbit.Consumer.DTOs.Consumer;

namespace Rabbit.Consumer.Consumer
{
    public class PixConsumer :
        IConsumer<PixTransfer>
    {
        public async Task Consume(ConsumeContext<PixTransfer> context)
        {
            var result = context.Message;
        }
    }
}
