using Newtonsoft.Json;
using OireachtasAPI.Model;
using OireachtasAPI.Services;
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
            return (new System.IO.StreamReader(fileName)).ReadToEnd();
        }
        public static object LoadJson(Uri url)
        {
            IOireachtasService oireachtasService = new OireachtasService();
            if (url.AbsoluteUri.Contains("legislation"))
            {
                LegislationBase legislation = new LegislationBase();
                legislation = JsonConvert.DeserializeObject<LegislationBase>(oireachtasService.Get(50, url).Result);
                return legislation;
            }
            else
            {
                MemberBase member = new MemberBase();
                member = JsonConvert.DeserializeObject<MemberBase>(oireachtasService.Get(50, url).Result);
                return member;
            }
        }
    }
}
