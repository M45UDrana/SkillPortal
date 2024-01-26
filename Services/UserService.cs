using SkillPortal.Data;
using SkillPortal.Models;
using SkillPortal.Models.Dto;
using SkillPortal.Services.Interfaces;

namespace SkillPortal.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUserByEmail(string email)
        {
            return _unitOfWork.Users.GetUserByEmail(email);
        }

        public void AddUser(RegisterModel model)
        {
            User user = new User
            {
                FullName = model.FullName,
                Password = model.Password,
                Role = model.Role,
                IsActive = true,
                Emails = new List<Email>
                {
                    new Email { EmailAddress = model.Email, IsPrimary = true }
                }
            };

            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
        }
    }
}
