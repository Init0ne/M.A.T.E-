using MarketAnalyzerToolsExpert.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketAnalyzerToolsExpert.Data.Repositories
{
    public class CompanyRepository(FinancialDataContext context)
    {

        /// <summary>
        /// Obtener todas las empresas
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await context.Companies.ToListAsync();
        }

        /// <summary>
        /// Obtener una empresa por su ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<Company?> GetCompanyByIdAsync(int companyId)
        {
            return await context.Companies.FindAsync(companyId);
        }

        /// <summary>
        /// Agregar una nueva empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task AddCompanyAsync(Company company)
        {
            context.Companies.Add(company);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizar una empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task UpdateCompanyAsync(Company company)
        {
            context.Companies.Update(company);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Eliminar una empresa
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task DeleteCompanyAsync(int companyId)
        {
            var company = await context.Companies.FindAsync(companyId);
            if (company != null)
            {
                context.Companies.Remove(company);
                await context.SaveChangesAsync();
            }
        }
    }
}
