using Tattoo.Entities;

namespace Tattoo.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User, string>
    {
        Task<User?> FindByUsername(string username);
        bool ExistsByUsername(string username);
    }
}
