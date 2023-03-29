namespace UnitTestMasters_Session7Assignment.Utility
{
    public class MessageBus
    {
        private readonly IBus _bus;
        public MessageBus(IBus bus)
        {
            _bus = bus;
        }
        public void SendOrderProcessedMessage(int orderId)
        {
            _bus.Send($"Subject: ORDER; Type: Order Processed; Id: {orderId};");
        }
    }
}