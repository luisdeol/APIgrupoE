using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_GrupoE.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ActionName("Agenda")]
        public IEnumerable<string> GetAgenda()
        {
            char[] delimited = { ';', ',' };
            List<string> list = new List<string>();
            var fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/agenda_act.csv");
            string[] lines = System.IO.File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] bytes = utf8.GetBytes(line);
                //var stringLine = Encoding.UTF8.GetString(bytes);
                byte[] isoBytes = Encoding.Convert(utf8, iso, bytes);
                string str = iso.GetString(isoBytes);
                List<string> parts = str.Split(delimited).Select(p => p.Trim()).ToList();
                string linea = "";
                try
                {
                    linea = parts[1] + " " + parts[7] + " " + parts[20];
                    list.Add(linea);
                }
                catch { }
            }
            list.RemoveAt(0);
            return list;
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ActionName("Wifi_locations")]
        public IEnumerable<string> GetWifi()
        {
            char[] delimited = { ';', ',' };
            List<string> list = new List<string>();
            var fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Zonas_Wifi.csv");
            string[] lines = System.IO.File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] bytes = utf8.GetBytes(line);
                //var stringLine = Encoding.UTF8.GetString(bytes);
                byte[] isoBytes = Encoding.Convert(utf8, iso, bytes);
                string str = iso.GetString(isoBytes);
                List<string> parts = str.Split(delimited).Select(p => p.Trim()).ToList();
                string linea = "";
                try
                {
                    linea = parts[1] + " " + parts[2] + " " + parts[3] + " " + parts[8] + " " +parts[18] + " " +parts[19] + " " + parts [20];
                    list.Add(linea);
                }
                catch { }
            }
            list.RemoveAt(0);
            return list;
        }
        // GET api/values/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ActionName("Wifi_locations")]
        public string GetWifiId(int id)
        {
            List<string> list = (List<string>)GetWifi();
            return list.ElementAt(id);
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ActionName("Agenda")]
        public string GetEventId(int id)
        {
            List<string> list = (List<string>)GetAgenda();
            return list.ElementAt(id);
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
