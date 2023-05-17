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
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;

namespace muhtas2.Controllers
{
    [AllowAnonymous]
    public class MonitorController : Controller
    {
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
                jsonObject["ipAddress"] = groupEP.Address.ToString();
                jsonObject["port"] = groupEP.Port.ToString();

                Mcu mitem = new Mcu
                {
                    Blue = (UInt32)(jsonObject?["blue"] ?? 0),
                    Red = (UInt32)(jsonObject?["red"] ?? 0),
                    Green = (UInt32)(jsonObject?["green"] ?? 0),
                    Distance = (UInt32)(jsonObject?["distance"] ?? 0)
                };

                if (mitem.Blue > mitem.Red && mitem.Blue > mitem.Green)
                    jsonObject["biggest"] = "blue";
                else if (mitem.Red > mitem.Blue && mitem.Red > mitem.Green)
                    jsonObject["biggest"] = "red";
                else
                    jsonObject["biggest"] = "green";

                //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://harun:harun@cluster0.xubll8l.mongodb.net/?retryWrites=true&w=majority");
                //var client = new MongoClient(settings);
                //var database = client.GetDatabase("test");
                //var collection = database.GetCollection<Mcu>("Mcu");

                //collection.InsertOne(mitem);

                return Ok(JsonConvert.SerializeObject(jsonObject));
            }
            return Ok();

            //var item = _monitorDal.ReadAll();
            //return Ok(item);
        }
    }
}

