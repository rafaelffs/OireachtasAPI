using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OireachtasAPI.Model;
using OireachtasAPI.Utils;
using System.Linq;
using OireachtasAPI.Services.BillService;

namespace TestOireachtasAPI
{
    [TestClass]
    public class LoadDatasetTest
    {
        private MemberBase membersFromFileMock;
        private LegislationBase legislationFromFileMock;

        [TestInitialize]
        public void SetUp()
        {

        }

        [TestMethod]
        public void Test_LoadFromFile()
        {
            string loaded = JSONLoader.LoadJson(BillService.MEMBERS_DATASET);
            Assert.AreNotEqual("", loaded);
        }

        [TestMethod]
        public void Test_LoadFromFile_Member()
        {
            MemberBase loaded = JsonConvert.DeserializeObject<MemberBase>(JSONLoader.LoadJson(BillService.MEMBERS_DATASET));
            Assert.AreEqual(loaded.Members.Count, 50);
        }

        [TestMethod]
        public void Test_LoadFromFile_Legislation()
        {
            LegislationBase loaded = JsonConvert.DeserializeObject<LegislationBase>(JSONLoader.LoadJson(BillService.LEGISLATION_DATASET));
            Assert.AreEqual(loaded.Legislations.Count, 50);
        }

        [TestMethod]
        public void Test_LoadFromFile_InvalidFile()
        {
            string loaded = JSONLoader.LoadJson("invalid.json");
            Assert.AreEqual(loaded, "");
        }

        [TestMethod]
        public void Test_LoadFromUrl()
        {
            string loaded = JSONLoader.LoadJson(new Uri("https://api.oireachtas.ie/v1/members?limit=50"));
            Assert.AreNotEqual("", loaded);
        }


        [TestMethod]
        public void Test_LoadFromUrl_Member()
        {
            MemberBase loaded = JsonConvert.DeserializeObject<MemberBase>(JSONLoader.LoadJson(new Uri("https://api.oireachtas.ie/v1/members?limit=50")));
            Assert.AreEqual(loaded.Members.Count, 50);
        }

        [TestMethod]
        public void Test_LoadFromUrl_Legislation()
        {
            LegislationBase loaded = JsonConvert.DeserializeObject<LegislationBase>(JSONLoader.LoadJson(new Uri("https://api.oireachtas.ie/v1/legislation?limit=50")));
            Assert.AreEqual(loaded.Legislations.Count, 50);
        }
    }
}
