using DataAccess.DbAcccess;
using DataModels.Models;

namespace DataAccess.Data.Services;

public class MovieService : IMovieService
{
    private readonly ISqlDataAccess _db;

    public MovieService(ISqlDataAccess db)
    {
        _db = db;
    }
    public Task<IEnumerable<Movie>> getMovies() =>
        _db.LoadData<Movie, dynamic>(storedProcedure: "dbo.spMovie_GetAll", new { });

    public async Task<Movie?> GetMovie(int id)
    {
        var results = await _db.LoadData<Movie, dynamic>(storedProcedure: "dbo.spMovie_Get", new { Id = id });

        return results.FirstOrDefault();
    }

    // Save The changes in the crud functions.....
    public Task createMovie(Movie movie) =>
        _db.SaveData(storedProcedure: "spMovie_Insert", new { movie.title, movie.description, movie.rating });
    public Task UpdateMovie(Movie movie) =>
        _db.SaveData(storedProcedure: "dbo.spMovie_Update", movie);
    public Task DeleteMovie(int id) =>
        _db.SaveData(storedProcedure: "dbo.spMovie_Delete", new { Id = id });




}
