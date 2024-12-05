using FARSOUND.Application.Models;
using FARSOUND.Application.Context;
using FARSOUND.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task UpdateAsync(int id, InsertUpdateUser updateUser)
        {
            var user = await _FARSOUNDDbContext
                 .Users.SingleAsync(x => x.Id == id);


            user.UserName = updateUser.UserName;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.SecurityAnswer = updateUser.SecurityAnswer;
            user.SecurityQuestion = updateUser.SecurityQuestion;

            await _FARSOUNDDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _FARSOUNDDbContext
    .Users.SingleAsync(x => x.Id == id);

            _FARSOUNDDbContext.Remove(user);

            await _FARSOUNDDbContext.SaveChangesAsync();
        }

    }
}
