using SkillPortal.Data.DbContexts;
using SkillPortal.Data.Repositories.Interfaces;
using SkillPortal.Models;

namespace SkillPortal.Data.Repositories
{
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(SkillPortalDbContext context) : base(context)
        {
        }
    }
}
