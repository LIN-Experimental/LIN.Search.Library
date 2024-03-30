using System;

namespace LIN.Exp.Search.Http;


internal class Weather
{

    /// <summary>
    /// Obtener el clima de una ciudad.
    /// </summary>
    /// <param name="city">Ciudad.</param>
    public static async Task<WeatherData?> Get(string city)
    {

        // Cliente.
        Global.Http.Services.Client client = new()
        {
            BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather"),
            TimeOut = 7
        };

        // Parámetros.
        client.AddParameter("q", city);
        client.AddParameter("appid", Client.WeatherKey);
        client.AddParameter("units", "metric");

        // Respuesta.
        var response = await client.Get<WeatherData>();

        // Retornar.
        return response;

    }


}
