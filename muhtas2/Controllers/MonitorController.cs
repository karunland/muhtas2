using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Calabonga.Mvc.ApiExtensions;
using System.Text.Json.Nodes;

namespace muhtas2.Controllers
{
    public class MonitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Route("api/[controller]")]
        [HttpPost]
        public IActionResult sensor()
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
                    int redValue = (int)(jsonObject?["red"] ?? 0);
                    int blueValue = (int)(jsonObject?["blue"] ?? 0);
                    int greenValue = (int)(jsonObject?["green"] ?? 0);
                    int distanceValue = (int)(jsonObject?["distance"] ?? 0);
                    
                    //Console.WriteLine($"red={redValue}, blue={blueValue}, green={greenValue}, distance={distanceValue}");
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
            string item = JsonConvert.SerializeObject(jsonObject);

            return Ok(item);

        }
    }
}

