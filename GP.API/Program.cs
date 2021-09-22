using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace GP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://0.0.0.0:5001")
                .UseStartup<Startup>();
    }
}
