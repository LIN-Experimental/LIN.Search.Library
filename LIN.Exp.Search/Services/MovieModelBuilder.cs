using LIN.Exp.Search.Models.Weather;
using LIN.Types.Exp.Search.Enums;
using System.Linq;

namespace LIN.Exp.Search.Services;

internal class MovieModelBuilder
{


    public static LIN.Types.Exp.Search.Models.Movie? Build(Models.Movies.Movie? data)
    {

        if (data == null)
            return null;


        var movie = new Types.Exp.Search.Models.Movie
        {
            Actors = data.Actors.Split(',').ToList(),
            Description = data.Plot,
            Name = data.Title,
            Poster = data.Poster,
            Rating = data.imdbRating,
            Released = data.Released,
            Year = data.Year,
        };

        return movie;

    }

}