using System;
using System.Net;
using System.Net.Sockets;

namespace Forza7Telemetry.Monitor
{
    public class TelemetryListener
    {
        private int Port { get; set; }

        private UdpClient UdpListener { get; set; }

        private bool Running { get; set; }

        private Action<byte[]> MessageProcessor { get; set; }

        public TelemetryListener(int portNumber, Action<byte[]> messageProcessor)
        {
            this.Port = portNumber;
            this.UdpListener = new UdpClient(this.Port);
            this.Running = false;
            this.MessageProcessor = messageProcessor;
        }

        public void StartListener()
        {
            var groupEndpoint = new IPEndPoint(IPAddress.Any, this.Port);
            this.Running = true;
            try
            {
                while (this.Running)
                {
                    byte[] bytes = this.UdpListener.Receive(ref groupEndpoint);
                    this.MessageProcessor(bytes);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                this.UdpListener.Close();
            }
        }

        public void StopListener()
        {
            this.Running = false;
        }
    }
}
