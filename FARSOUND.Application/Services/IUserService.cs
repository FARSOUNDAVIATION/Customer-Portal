using FARSOUND.Application.Models;

namespace FARSOUND.Application.Services
{
    public interface IUserService
    {
        Task<int> InsertAsync(InsertUpdateUser insertUser);

        Task UpdateAsync(int id, InsertUpdateUser updateUser);
        Task DeleteAsync(int id);
    }
}
