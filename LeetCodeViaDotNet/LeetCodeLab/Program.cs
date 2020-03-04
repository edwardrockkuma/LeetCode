using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace LeetCodeLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            //BinaryGap binaryGap = new BinaryGap();
            //binaryGap.FindMaxGap(2147483600);
            //binaryGap.FindMaxGap(529);
            Solution77 sol77 = new Solution77();
            if(sol77.IsValid("{[]}"))
            {
                Console.WriteLine("right");
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
