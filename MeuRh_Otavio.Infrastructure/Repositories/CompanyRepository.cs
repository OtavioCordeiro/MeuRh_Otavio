using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;
using MeuRh_Otavio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RhDbContext _context;

        public CompanyRepository(RhDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetById(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task Add(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }
    }
}
