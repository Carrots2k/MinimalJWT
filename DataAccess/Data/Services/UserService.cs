using DataAccess.DbAcccess;
using DataAccess.JWT;
using DataModels.Models;

namespace DataAccess.Data.Services;

public class UserService : IUserService
{
    private readonly ISqlDataAccess _db;
    private readonly IUserAuth _auth;
    public UserService(ISqlDataAccess db, IUserAuth auth)
    {
        _db = db;
        _auth = auth;
    }
    public async Task<String> GetUser(UserLogin user)
    {
        var results = await _db.LoadData<User, dynamic>(storedProcedure: "dbo.spUser_GetUserLogin", new { user.username, user.password});
        string gg = "";
        
        if(results.Count() == 0)
            return null;

        var token = _auth.AuthUser(results.FirstOrDefault());
        return token;
    }
}
