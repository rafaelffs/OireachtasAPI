using Microsoft.VisualStudio.TestTools.UnitTesting;
using OireachtasAPI.Model;
using OireachtasAPI.Services.OireachtasService;
using System;

namespace TestOireachtasAPI
{
    [TestClass]
    public class OireachtasServiceTest
    {
        IOireachtasService oireachtasService;
        [TestInitialize]
        public void SetUp()
        {
            oireachtasService = new OireachtasService();
        }

        [TestMethod]
        public void Test_Legislation()
        {
            LegislationBase result = oireachtasService.GetLegislation(50).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Legislations.Count, 50);
        }

        [TestMethod]
        public void Test_Member()
        {
            MemberBase result = oireachtasService.GetMember(50).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Members.Count, 50);
        }

        [TestMethod]
        public void Test_Get()
        {
            object result =  oireachtasService.Get(new Uri("https://api.oireachtas.ie/v1/members?limit=50")).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Get_InvalidURL()
        {
            object result = oireachtasService.Get(new Uri("https://api.wrongurl.ie/v1/members?limit=50")).Result;
            Assert.AreEqual(result, "");
        }
    }
}
