using DataAccesss.Abstract;
using DataAccesss.Concrete;
using Entity.DbModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;

namespace DataAccesss.EntityFramework
{
    public class EfMonitorDal : IMonitorDal
    {
        public string ReadAll()
        {
            var port = 5000;
            JObject jsonObject = new JObject();
            var listener = new UdpClient(port);
            IPAddress ipAddress = IPAddress.Parse("192.168.0.15");
            IPEndPoint groupEP = new IPEndPoint(ipAddress, port);
            try
            {
                Console.WriteLine("Server started listening on {0}:{1}", groupEP.Address, groupEP.Port);

                byte[] bytes = listener.Receive(ref groupEP);
                string udpData = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                try
                {
                    jsonObject = JObject.Parse(udpData);
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine("Geçersiz JSON: " + ex.Message);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
            if (jsonObject != null)
            {
                using (var c = new Context())
                {
                    string item = JsonConvert.SerializeObject(jsonObject);

                    Mcu mitem = new Mcu
                    {
                        Blue = (UInt32)(jsonObject?["blue"] ?? 0),
                        Red = (UInt32)(jsonObject?["red"] ?? 0),
                        Green = (UInt32)(jsonObject?["green"] ?? 0),
                        Distance = (UInt32)(jsonObject?["distance"] ?? 0)
                    };

                    c.Add(mitem);
                    c.SaveChanges();

                    return item ?? "";
                }
            }
            return "";
        }
    }
}
