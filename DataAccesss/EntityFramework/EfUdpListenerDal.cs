using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesss.EntityFramework
{
    public class EfUdpListenerDal
    {
        private UdpClient _udpClient;
        private CancellationTokenSource _cancellationTokenSource;

        public void UdpListenerService(int port)
        {
            _udpClient = new UdpClient(port);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async Task StartAsync()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var receivedResult = await _udpClient.ReceiveAsync();
                // handle received data here
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _udpClient.Close();
        }
    }
}
