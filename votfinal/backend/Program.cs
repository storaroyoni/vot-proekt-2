using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}



public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(10, 4, 14))));
}
