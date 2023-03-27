namespace BetweenNet
{
    public class ServerConnector : BaseConnector<ServerConnector>
    {
        public void StartServer()
        {
            ReceivingLoop();
        }
    }
}
