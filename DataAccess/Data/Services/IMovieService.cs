using DataModels.Models;

namespace DataAccess.Data.Services
{
    public interface IMovieService
    {
        Task createMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<Movie?> GetMovie(int id);
        Task<IEnumerable<Movie>> getMovies();
        Task UpdateMovie(Movie movie);
    }
}