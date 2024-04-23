using DataModels.Models;

namespace DataAccess.JWT
{
    public interface IUserAuth
    {
        String AuthUser(User user);
    }
}