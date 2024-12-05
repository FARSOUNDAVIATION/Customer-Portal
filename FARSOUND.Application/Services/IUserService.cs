using FARSOUND.Application.Models;

namespace FARSOUND.Application.Services
{
    public interface IUserService
    {
        Task<int> InsertAsync(InsertUpdateUser insertUser);
    }
}
