using DataModels.Models;

namespace DataAccess.Data.Services;

public interface IUserService
{
    Task<String> GetUser(UserLogin user);
}