using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OireachtasAPI.Model;
using OireachtasAPI.Services;
using OireachtasAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OireachtasAPI
{
    public class Program
    {
        public static string LEGISLATION_DATASET = "legislation.json";
        public static string MEMBERS_DATASET = "members.json";
        private static IOireachtasService OireachtasService = new OireachtasService();

        static void Main(string[] args)
        {

        }

        /// <summary>
        /// Return bills sponsored by the member with the specified pId
        /// </summary>
        /// <param name="pId">The pId value for the member</param>
        /// <returns>List of bill records</returns>
        public static IList<Bill> FilterBillsSponsoredBy(string pId)
        {
            LegislationBase legislation = JsonConvert.DeserializeObject<LegislationBase>(JSONLoader.LoadJson(LEGISLATION_DATASET));
            MemberBase member = JsonConvert.DeserializeObject<MemberBase>(JSONLoader.LoadJson(MEMBERS_DATASET));

            //LegislationBase legislation = OireachtasService.GetLegislation(50).Result;
            //MemberBase member = OireachtasService.GetMember(50).Result;

            IList<Bill> bills = legislation.Legislations.
                Where(x => x.Bill.Sponsors.Any(y => member.Members.Any(z => z.Member.PId == pId && z.Member.FullName == y.Sponsor.By.ShowAs)))
                    .Select(x => x.Bill).ToList();
            return bills;
        }

        /// <summary>
        /// Return bills updated within the specified date range
        /// </summary>
        /// <param name="since">The lastUpdated value for the bill should be greater than or equal to this date</param>
        /// <param name="until">The lastUpdated value for the bill should be less than or equal to this date.If unspecified, until will default to today's date</param>
        /// <returns>List of bill records</returns>
        public static List<dynamic> filterBillsByLastUpdated(DateTime since, DateTime until)
        {
            throw new NotImplementedException();
        }
    }
}
