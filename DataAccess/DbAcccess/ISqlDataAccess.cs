namespace DataAccess.DbAcccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connecttionId = "DbConn");
        Task SaveData<T>(string storedProcedure, T parameteres, string connectionId = "DbConn");
    }
}