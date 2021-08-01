using OireachtasAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Services.BillService
{
    public interface IBillService
    {
        IList<Bill> FilterBillsSponsoredBy(string pId, bool useFile);
        IList<Bill> FilterBillsByLastUpdated(DateTime since, DateTime until, bool useFile);
    }
}
