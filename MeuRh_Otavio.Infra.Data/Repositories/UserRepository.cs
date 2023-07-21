using MeuRh_Otavio.Domain.Entities;
using MeuRh_Otavio.Domain.Interfaces;
using MeuRh_Otavio.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MeuRh_Otavio.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RhDbContext _context;

        public UserRepository(RhDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id, bool includeCompanies = false)
        {
            IQueryable<User> query = _context.Users;

            if (includeCompanies)
            {
                query = query.Include(u => u.Companies)
                             .ThenInclude(uc => uc.Company);
            }

            return await query.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
