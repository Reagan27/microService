namespace MicroService_Email.Massaging
{
    public interface IAzureMessageBusConsumer
    {
       public Task Start();


       public Task Stop();
    }
}
