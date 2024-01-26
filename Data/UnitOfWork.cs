using SkillPortal.Data.DbContexts;
using SkillPortal.Data.Repositories;
using SkillPortal.Data.Repositories.Interfaces;

namespace SkillPortal.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SkillPortalDbContext _context;
        private IEmailRepository? _emails;
        private IEmployeeRepository? _employees;
        private ISkillRepository? _skills;
        private IUserRepository? _users;

        public UnitOfWork(SkillPortalDbContext context)
        {
            _context = context;
        }

        public IEmailRepository Emails => _emails ??= new EmailRepository(_context);
        public IEmployeeRepository Employees => _employees ??= new EmployeeRepository(_context);
        public ISkillRepository Skills => _skills ??= new SkillRepository(_context);
        public IUserRepository Users => _users ??= new UserRepository(_context);

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
