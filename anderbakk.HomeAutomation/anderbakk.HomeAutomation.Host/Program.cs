using System;
using anderbakk.HomeAutomation.WebApi;
using Microsoft.Owin.Hosting;

namespace anderbakk.HomeAutomation.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                var app = new WebApiApplication();
                
                Console.ReadLine();
            }
        }
    }
}
