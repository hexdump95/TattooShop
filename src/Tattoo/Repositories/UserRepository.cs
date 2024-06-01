using Tattoo.Data;
using Tattoo.Entities;
using Tattoo.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Tattoo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Save(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> FindByUsername(string username)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users
                .Any(u => u.Username == username);
        }
    }
}
