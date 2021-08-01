using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Model
{
    public class LegislationBase
    {
        [JsonProperty("results")]
        public IList<Legislation> Legislations { get; set; }
    }
    public class Legislation
    {
        [JsonProperty("bill")]
        public Bill Bill { get; set; }
    }
}
