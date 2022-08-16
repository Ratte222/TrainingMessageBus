using MassTransit;
using TrainingMessageBus.Dto;

namespace TrainingMessageBus.Consumers
{
    public class MessageConsumer : IConsumer<SimpleMessage>
    {
        public  Task Consume(ConsumeContext<SimpleMessage> context)
        {
            Console.WriteLine($"Receive message: {context.Message.Content}");
            return Task.CompletedTask;
        }
    }
}
