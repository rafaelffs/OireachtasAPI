using Microsoft.VisualStudio.TestTools.UnitTesting;
using OireachtasAPI.Model;
using OireachtasAPI.Services.BillService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestOireachtasAPI
{
    [TestClass]
    public class BillServiceTest
    {
        private IBillService billService;
        public IList<Bill> billsMock;


        [TestInitialize]
        public void SetUp()
        {
            billService = new BillService();
            billsMock = new List<Bill>(){
                new Bill(){BillNo= "77"},
                new Bill(){BillNo= "101"},
                new Bill(){BillNo= "58"},
                new Bill(){BillNo= "141"},
                new Bill(){BillNo= "55"},
                new Bill(){BillNo= "133"},
                new Bill(){BillNo= "132"},
                new Bill(){BillNo= "131"},
                new Bill(){BillNo= "111"},
                new Bill(){BillNo= "135"},
                new Bill(){BillNo= "134"},
                new Bill(){BillNo= "91"},
                new Bill(){BillNo= "129"},
                new Bill(){BillNo= "103"},
                new Bill(){BillNo= "138"},
                new Bill(){BillNo= "106"},
                new Bill(){BillNo= "139"},
            };
        }

        [TestMethod]
        public void Test_FilterBillsSponsoredBy_File()
        {
            IList<Bill> results = billService.FilterBillsSponsoredBy("IvanaBacik", true);
            Assert.IsTrue(results.Count >= 2);
        }

        [TestMethod]
        public void Test_FilterBillsSponsoredBy_URL()
        {
            IList<Bill> results = billService.FilterBillsSponsoredBy("IvanaBacik", false);
            Assert.IsTrue(results.Count >= 1);
        }

        [TestMethod]
        public void Test_FilterBillsByLastUpdated_File()
        {
            DateTime since = new DateTime(2018, 12, 1);
            DateTime until = new DateTime(2019, 1, 1);
            IList<Bill> received = billService.FilterBillsByLastUpdated(since, until, true);
            CollectionAssert.AreEqual(billsMock.OrderBy(x => x.BillNo).Select(x => x.BillNo).ToList(), received.OrderBy(x => x.BillNo).Select(x => x.BillNo).ToList());
        }

        [TestMethod]
        public void Test_FilterBillsByLastUpdated_URL()
        {
            DateTime since = new DateTime(2021, 1, 1);
            DateTime until = new DateTime(2021, 12, 1);
            IList<Bill> received = billService.FilterBillsByLastUpdated(since, until, false);
            Assert.IsTrue(received.Count >= 1);
        }

        [TestMethod]
        public void Test_FilterBillsByLastUpdated_SinceDate_Greater_Than_UntilDate()
        {
            DateTime since = new DateTime(2020, 12, 1);
            DateTime until = new DateTime(2019, 1, 1);
            IList<Bill> received = billService.FilterBillsByLastUpdated(since, until, true);
            Assert.IsNull(received);
        }


    }
}
