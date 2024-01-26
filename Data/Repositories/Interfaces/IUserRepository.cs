using SkillPortal.Models;

namespace SkillPortal.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
