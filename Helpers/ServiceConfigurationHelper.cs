using MarketAnalyzerToolsExpert.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketAnalyzerToolsExpert.Helpers
{
    public static class ServiceConfigurationHelper
    {
        public static IServiceProvider ConfigureServices()
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectRoot)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ServiceCollection services = new();

            services.AddDbContext<FinancialDataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FinancialData"));
            });

            return services.BuildServiceProvider();
        }
    }
}
