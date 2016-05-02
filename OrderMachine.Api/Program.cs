using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace OrderMachine.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000";
            WebApp.Start<Startup>(url: baseAddress);
            Console.ReadKey();
        }
    }
}
