using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VueChatApp
{
    public class Program
    {
        //private IHostingEnvironment env;
        public static void Main(string[] args)
        {
            CreatWebHostBuilder(args).Build().Run();
        }
        private static IWebHostBuilder CreatWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseKestrel(options =>
                {
                    //TODO remove hard corded port
                    options.ListenAnyIP(49615);
                });
    }
}
