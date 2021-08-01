using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Model
{
    public class Bill
    {
        [JsonProperty("billNo")]
        public string BillNo { get; set; }
        [JsonProperty("sponsors")]
        public List<SponsorBase> Sponsors { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

    }
}
