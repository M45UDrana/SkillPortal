using SkillPortal.Data.Repositories.Interfaces;

namespace SkillPortal.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IEmailRepository Emails { get; }
        IEmployeeRepository Employees { get; }
        ISkillRepository Skills { get; }
        IUserRepository Users { get; }
        int Save();
    }
}
