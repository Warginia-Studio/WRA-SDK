using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Patterns;
using UnityEngine;
using Utility.Diagnostics;

namespace BetweenNet
{
    public class BaseConnector<T> : Singleton<T> where T : new()
    {
        protected static UdpClient udpClient = new UdpClient(5000);
        protected static bool isOn = true;
        protected List<ReceivedData> receivedDatas = new List<ReceivedData>();

        protected async void ReceivingLoop()
        {
            WraDiagnostics.Log("Starting listiening.");
            isOn = true;
            while (isOn)
            {
                try
                {
                    UdpReceiveResult result = await udpClient.ReceiveAsync();
                    // string message = Encoding.ASCII.GetString(result.Buffer);
                    receivedDatas.Add(new ReceivedData() { UdpReceiveResult = result, ReceivedAt = DateTime.Now});
                    // Console.WriteLine("Received message: " + message);
                    // Do something with the message
                }
                catch (Exception ex)
                {
                    WraDiagnostics.LogError($"[{DateTime.Now}] Exception while receiving data: " + ex.Message, Color.red);
                }
            }
        }
    }
}
