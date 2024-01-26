using SkillPortal.Models;
using SkillPortal.Models.Dto;

namespace SkillPortal.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        void AddUser(RegisterModel model);
    }
}
