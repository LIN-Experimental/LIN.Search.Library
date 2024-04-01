namespace LIN.Exp.Search;


public class Client
{


    /// <summary>
    /// Llave de Weather.
    /// </summary>
    internal static string WeatherKey {  get; set; } = string.Empty;


    /// <summary>
    /// Llave de movies.
    /// </summary>
    internal static string MoviesKey {  get; set; } = string.Empty;



    /// <summary>
    /// Obtener el tiempo.
    /// </summary>
    /// <param name="value">Ciudad</param>
    public static async Task<Types.Exp.Search.Models.Weather?> GetWeatherAsync(string value)
    {

        // Consulta a la API.
        var result = await Http.Weather.Get(value);

        // Construir el modelo.
        var final = Services.WeatherModelBuilder.Build(result);

        // Resultado.
        return final;

    }



    /// <summary>
    /// Buscar.
    /// </summary>
    /// <param name="value">Valor a buscar.</param>
    public static async Task<List<Types.Exp.Search.Models.SearchResult>> Search(string value)
    {

        // Consulta a la API.
        var result = await Http.Bing.Search(value);

        // Resultado.
        return result ?? [];

    }



    /// <summary>
    /// Buscar.
    /// </summary>
    /// <param name="value">Valor a buscar.</param>
    public static async Task<Movie> SearchMovie(string value)
    {

        // Consulta a la API.
        var result = await Http.Movies.Get(value);

        // Construir el modelo.
        var final = Services.MovieModelBuilder.Build(result);

        return final;

    }



    /// <summary>
    /// Establecer la key de Weather.
    /// </summary>
    /// <param name="api">Api.</param>
    public static void SetWeatherApi(string api)
    {
        WeatherKey = api;
    }




    /// <summary>
    /// Establecer la key de Movies.
    /// </summary>
    /// <param name="api">Api.</param>
    public static void SetMoviesApi(string api)
    {
        MoviesKey = api;
    }



}