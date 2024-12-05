using FARSOUND.Application.Models;
using FARSOUND.Application.Context;
using FARSOUND.Domain.Entities;

namespace FARSOUND.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IFARSOUNDDbContext
            _FARSOUNDDbContext;

        public UserService(
            IFARSOUNDDbContext FARSOUNDDbContext)
        {
            _FARSOUNDDbContext = FARSOUNDDbContext;
        }


        public async  Task<int> InsertAsync(InsertUpdateUser insertUser)
        {
            var user = new User
            {
                UserName = insertUser.UserName,
                Email = insertUser.Email,
                Password = insertUser.Password,
                SecurityAnswer = insertUser.SecurityAnswer,
                SecurityQuestion = insertUser.SecurityQuestion
            };

            await _FARSOUNDDbContext.Users.AddAsync(user);
            await _FARSOUNDDbContext.SaveChangesAsync();

            return user.Id;
           
        }


    }
}
