using OireachtasAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OireachtasAPI.Services
{
    public interface IOireachtasService
    {
        Task<LegislationBase> GetLegislation(int limit);
        Task<MemberBase> GetMember(int limit);
        Task<string> Get(int limit, Uri url);
    }
}
