using System;

namespace LIN.Exp.Search.Http;


internal class Movies
{

  
    public static async Task<Models.Movies.Movie?> Get(string name)
    {

        // Cliente.
        Global.Http.Services.Client client = new("http://www.omdbapi.com")
        {
            TimeOut = 7
        };

        // Parámetros.
        client.AddParameter("t", name);
        client.AddParameter("apikey", Client.MoviesKey);

        // Respuesta.
        var response = await client.Get<Models.Movies.Movie>();

        // Retornar.
        return response;

    }


}
