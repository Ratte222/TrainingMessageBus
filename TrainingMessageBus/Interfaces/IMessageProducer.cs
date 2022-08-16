namespace TrainingWithServiceBus.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
