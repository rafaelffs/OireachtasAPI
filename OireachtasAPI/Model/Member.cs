using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Model
{
    public class MemberBase
    {
        [JsonProperty("results")]
        public IList<MemberData> Members { get; set; }
    }
    public class MemberData
    {
        [JsonProperty("member")]
        public Member Member { get; set; }
    }
    public class Member
    {
        [JsonProperty("pId")]
        public string PId { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
    }
}
