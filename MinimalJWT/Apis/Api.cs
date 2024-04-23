using DataAccess.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace MinimalJWT.Apis;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        //My API endpoints mapped here....
        app.MapPost("/login", Login);
        app.MapGet("/movies", getMovies);
        app.MapGet("/movies/{id}", GetMovie);
        app.MapPost("/movies", InsertMovie);
        app.MapPut("/movies", UpdateMovie);
        app.MapDelete("/movies", DeleteMovie);
    }
    [AllowAnonymous]
    private static async Task<IResult> Login(UserLogin user, IUserService service, IUserAuth auth)
    {
        if(!string.IsNullOrEmpty(user.username) && !string.IsNullOrEmpty(user.password))
        {
            try
            {
                var userLoggedInToken =  await service.GetUser(user);
                if(userLoggedInToken == null) return Results.NotFound("Wrong username or password!");

                //string result = auth.AuthUser( await userLoggedInToken);
                return Results.Ok(userLoggedInToken);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        else
        {
            return Results.NotFound();
        }
    }

    /////////////////////////// Movies Api Functions /////////////////////////////
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "standard, Team Leader, admin")]
    private static async Task<IResult> getMovies(IMovieService data)
    {
        try
        {
            return Results.Ok(await data.getMovies());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "standard, Team Leader, admin")]
    private static async Task<IResult> GetMovie(int id, IMovieService data)
    {
        try
        {
            var results = await data.GetMovie(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Team Leader, admin")]
    private static async Task<IResult> InsertMovie(Movie movie, IMovieService data)
    {
        try
        {
            await data.createMovie(movie);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    private static async Task<IResult> UpdateMovie(Movie movie, IMovieService data)
    {
        try
        {
            await data.UpdateMovie(movie);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    private static async Task<IResult> DeleteMovie(int id, IMovieService data)
    {
        try
        {
            await data.DeleteMovie(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
