using MarketAnalyzerToolsExpert.Data.Repositories;
using MarketAnalyzerToolsExpert.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace MarketAnalyzerToolsExpert
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IServiceProvider serviceProvider = ServiceConfigurationHelper.ConfigureServices();

            // Obtener el repositorio de empresas
            CompanyRepository companyRepository = serviceProvider.GetRequiredService<CompanyRepository>();

            // Obtener y mostrar todas las empresas
            List<Models.Company> companies = await companyRepository.GetAllCompaniesAsync();
            Console.WriteLine($"Número de empresas en la base de datos: {companies.Count}");

            // Para evitar que la consola se cierre de inmediato
            Console.ReadLine();
        }
    }
}
