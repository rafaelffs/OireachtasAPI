using Newtonsoft.Json;
using OireachtasAPI.Model;
using OireachtasAPI.Services.OireachtasService;
using OireachtasAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Services.BillService
{
    public class BillService : IBillService
    {
        public static string LEGISLATION_DATASET = "legislation.json";
        public static string MEMBERS_DATASET = "members.json";
        public static string LEGISLATION_URL = "https://api.oireachtas.ie/v1/legislation?limit=50";
        public static string MEMBERS_URL = "https://api.oireachtas.ie/v1/members?limit=50";

        /// <summary>
        /// Return bills sponsored by the member with the specified pId
        /// </summary>
        /// <param name="pId">The pId value for the member</param>
        /// <returns>List of bill records</returns>
        public IList<Bill> FilterBillsSponsoredBy(string pId, bool useFile)
        {
            LegislationBase legislation;
            MemberBase member;
            IList<Bill> bills;
            if (useFile)
            {
                legislation = JsonConvert.DeserializeObject<LegislationBase>(JSONLoader.LoadJson(LEGISLATION_DATASET));
                member = JsonConvert.DeserializeObject<MemberBase>(JSONLoader.LoadJson(MEMBERS_DATASET));
            }
            else
            {
                legislation = JsonConvert.DeserializeObject<LegislationBase>(JSONLoader.LoadJson(new Uri(LEGISLATION_URL)));
                member = JsonConvert.DeserializeObject<MemberBase>(JSONLoader.LoadJson(new Uri(MEMBERS_URL)));
            }

            if (legislation != null && member != null)
            {
                bills = legislation.Legislations.
                    Where(leg => leg.Bill.Sponsors.Any(spo => member.Members.Any(mem => mem.Member.PId == pId && mem.Member.FullName == spo.Sponsor.By.ShowAs)))
                        .Select(leg => leg.Bill).ToList();
                return bills;
            }
            else
                return null;
        }

        /// <summary>
        /// Return bills updated within the specified date range
        /// </summary>
        /// <param name="since">The lastUpdated value for the bill should be greater than or equal to this date</param>
        /// <param name="until">The lastUpdated value for the bill should be less than or equal to this date.If unspecified, until will default to today's date</param>
        /// <returns>List of bill records</returns>
        public IList<Bill> FilterBillsByLastUpdated(DateTime since, DateTime until, bool useFile)
        {
            if (until == null || until == DateTime.MinValue)
                until = DateTime.Now;

            if (since > until)
                return null;
            LegislationBase legislation;
            if (useFile)
                legislation = JsonConvert.DeserializeObject<LegislationBase>(JSONLoader.LoadJson(LEGISLATION_DATASET));
            else
                legislation = JsonConvert.DeserializeObject<LegislationBase>(JSONLoader.LoadJson(new Uri(LEGISLATION_URL)));

            if (legislation != null)
                return legislation.Legislations.Where(leg => leg.Bill.LastUpdated >= since && leg.Bill.LastUpdated <= until).Select(leg => leg.Bill).ToList();
            return null;
        }
    }
}
