using SkillPortal.Data.DbContexts;
using SkillPortal.Data.Repositories.Interfaces;
using SkillPortal.Models;

namespace SkillPortal.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SkillPortalDbContext context) : base(context)
        {
        }
    }
}
