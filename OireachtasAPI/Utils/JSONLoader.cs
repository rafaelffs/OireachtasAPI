using Newtonsoft.Json;
using OireachtasAPI.Model;
using OireachtasAPI.Services;
using OireachtasAPI.Services.OireachtasService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Utils
{
    public class JSONLoader
    {
        public static string LoadJson(string fileName)
        {
            string data;
            try
            {
                data = new System.IO.StreamReader(fileName).ReadToEnd();
            }
            catch
            {
                data = "";
            }
            return data;
        }
        public static string LoadJson(Uri url)
        {
            IOireachtasService oireachtasService = new OireachtasService();
            return oireachtasService.Get(url).Result;
        }
    }
}
