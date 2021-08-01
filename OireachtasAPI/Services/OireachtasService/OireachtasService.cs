using Newtonsoft.Json;
using OireachtasAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Services.OireachtasService
{
    public class OireachtasService : IOireachtasService
    {
        public string baseUrl = "https://api.oireachtas.ie/v1/";
        static HttpClient httpClient = new HttpClient();

        public async Task<LegislationBase> GetLegislation(int limit = 50)
        {
            LegislationBase legislation = new LegislationBase();
            HttpResponseMessage response = await httpClient.GetAsync(this.baseUrl + $"legislation?limit={limit}");
            if (response.IsSuccessStatusCode)
            {
                legislation = JsonConvert.DeserializeObject<LegislationBase>(response.Content.ReadAsStringAsync().Result);
            }
            return legislation;
        }

        public async Task<MemberBase> GetMember(int limit = 50)
        {
            MemberBase member = new MemberBase();
            HttpResponseMessage response = await httpClient.GetAsync(this.baseUrl + $"members?limit={limit}");
            if (response.IsSuccessStatusCode)
            {
                member = JsonConvert.DeserializeObject<MemberBase>(response.Content.ReadAsStringAsync().Result);
            }
            return member;
        }
        public async Task<string> Get(Uri url)
        {
            string data = "";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                    data = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                
            }
            return data;
        }


    }
}
