using Microsoft.AspNetCore.Mvc;
using DataAccesss.Abstract;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Calabonga.Mvc.ApiExtensions;
using System.Text.Json.Nodes;
using DataAccesss.EntityFramework;
using DataAccesss.Concrete;
using Entity.DbModel;

namespace muhtas2.Controllers
{
    public class MonitorController : Controller
    {
        //IMonitorDal _monitorDal;
        //public MonitorController(IMonitorDal monitorDal)
        //{
        //    _monitorDal = monitorDal;
        //}
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult sensor()
        {
            var port = 5000;
            JObject jsonObject = new JObject();
            var listener = new UdpClient(port);
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
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

                    return Ok(item);
                }
            }
            return Ok();

            //var item = _monitorDal.ReadAll();
            //return Ok(item);
        }
    }
}

