using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System.Diagnostics;
using System.Linq;

namespace restful_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            bool isService = !(Debugger.IsAttached || args.Contains("--console")); //Debug状态或者程序参数中带有--console都表示普通运行方式而不是Windows服务运行方式
            if (isService)
            {
                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://localhost:8081")
                .UseStartup<Startup>();
    }
}
