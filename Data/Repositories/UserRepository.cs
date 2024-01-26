using Microsoft.EntityFrameworkCore;
using SkillPortal.Data.DbContexts;
using SkillPortal.Data.Repositories.Interfaces;
using SkillPortal.Models;

namespace SkillPortal.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SkillPortalDbContext context) : base(context)
        {
        }

        public User GetUserByEmail(string email)
        {
            var user = SkillPortalDbContext.Users
                .Include(u => u.Emails)
                .FirstOrDefault(u => u.Emails.Any(e => e.EmailAddress == email && e.IsPrimary == true));

            return user;
        }

        public SkillPortalDbContext SkillPortalDbContext
        {
            get { return Context as SkillPortalDbContext; }
        }
    }
}
