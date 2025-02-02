using MarketAnalyzerToolsExpert.Data;
using MarketAnalyzerToolsExpert.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace MarketAnalyzerToolsExpert
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Configurar el servicio de inyección de dependencias
            IServiceProvider serviceProvider = ServiceConfigurationHelper.ConfigureServices();

            // Obtener una instancia del DbContext
            using FinancialDataContext context = serviceProvider.GetRequiredService<FinancialDataContext>();

            // Ejemplo de uso: Consultar todas las empresas
            List<Models.Company> companies = [.. context.Companies];
            Console.WriteLine($"Número de empresas en la base de datos: {companies.Count}");
        }
    }
}