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

        // URL de la API de OpenWeatherMap
        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={Client.WeatherKey}&units=metric";

        // Cliente.
        using HttpClient client = new()
        {
            Timeout = TimeSpan.FromSeconds(5)
    };

        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            // Obtener el contenido.
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializar la respuesta JSON en un objeto WeatherData
            WeatherData? weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);

            return weatherData;
        }
        catch
        {
        }
        return null;
    }


}
