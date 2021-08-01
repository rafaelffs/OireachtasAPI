using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OireachtasAPI.Model;
using OireachtasAPI.Services;
using OireachtasAPI.Services.BillService;
using OireachtasAPI.Services.OireachtasService;
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
        static void Main(string[] args)
        {
            IBillService billService = new BillService();
            IList<Bill> bills;
            bool useFile = false;

            Console.WriteLine("Use a local file or connect to Oireachtas API? ");
            Console.WriteLine("1 - Local file");
            Console.WriteLine("2 - Oireachtas API");

            string selection = Console.ReadLine();
            while (selection != "1" && selection != "2")
            {
                Console.WriteLine("Wrong option");
                selection = Console.ReadLine();
            }
            switch (selection)
            {
                case "1":
                    useFile = true;
                    break;
                case "2":
                    useFile = false;
                    break;
            }
            Console.WriteLine("Please select a option: ");
            Console.WriteLine("1 - FilterBillsSponsoredBy");
            Console.WriteLine("2 - FilterBillsByLastUpdated");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("pID: ");
                    var pID = Console.ReadLine();
                    bills = billService.FilterBillsSponsoredBy(pID, useFile);
                    WriteBills(bills);
                    break;
                case "2":
                    Console.WriteLine("Since: (dd-mm-yyyy format): ");
                    string inputSinceData = Console.ReadLine();
                    Console.WriteLine("Until: (dd-mm-yyyy format): ");
                    string inputUntilData = Console.ReadLine();

                    if (ValidateDateTime.IsValidDateTime(inputSinceData) && (ValidateDateTime.IsValidDateTime(inputUntilData) || inputUntilData == ""))
                    {
                        DateTime since = ValidateDateTime.ConvertInputToDateTime(inputSinceData);
                        DateTime until = ValidateDateTime.ConvertInputToDateTime(inputUntilData);
                        bills = billService.FilterBillsByLastUpdated(since, until, useFile);
                        WriteBills(bills);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input format.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue.");
                    break;
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }

        private static void WriteBills(IList<Bill> bills)
        {
            Console.WriteLine($"Total bills: {bills.Count}");
            foreach (Bill bill in bills)
            {
                Console.WriteLine($"Bill no: {bill.BillNo}");
            }
            Console.WriteLine();
        }

    }
}
