using MassTransit;
using TrainingMessageBus.Dto;

namespace TrainingMessageBus
{
    public class BackgroundWorker : BackgroundService
    {
        private readonly IBus _bus;

        public BackgroundWorker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new SimpleMessage() { Content = "This is simple message content!" }, stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
