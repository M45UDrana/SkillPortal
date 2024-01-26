using SkillPortal.Data.DbContexts;
using SkillPortal.Data.Repositories.Interfaces;
using SkillPortal.Models;

namespace SkillPortal.Data.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(SkillPortalDbContext context) : base(context)
        {
        }
    }
}
