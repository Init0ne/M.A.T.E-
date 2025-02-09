using MarketAnalyzerToolsExpert.Data;
using MarketAnalyzerToolsExpert.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketAnalyzerToolsExpert.Repositories
{
    public class CompanyRepository
    {
        private readonly FinancialDataContext _context;

        public CompanyRepository(FinancialDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todas las empresas
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        /// <summary>
        /// Obtener una empresa por su ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<Company?> GetCompanyByIdAsync(int companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        /// <summary>
        /// Agregar una nueva empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task AddCompanyAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualizar una empresa
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task UpdateCompanyAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Eliminar una empresa
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task DeleteCompanyAsync(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}
