using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace BetweenNet
{
    public class ClientConnector : BaseConnector<ClientConnector>
    {

        public void TryConnectToTheServer(string ip, ushort port)
        {
            udpClient = new UdpClient(ip, port);
            ReceivingLoop();
        
        }

        public void Send(object obj)
        {
            string str = JsonConvert.SerializeObject(obj);
            udpClient.Send(Encoding.ASCII.GetBytes(str), str.Length);
        }
    }
}
