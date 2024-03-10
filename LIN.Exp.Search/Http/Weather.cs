using LIN.Exp.Search.Models.Weather;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace LIN.Exp.Search.Http;

internal class Weather
{


    public static async Task<WeatherData?> Get(string city)
    {

        // URL de la API de OpenWeatherMap
        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={Client.WeatherKey}&units=metric";

        using HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

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
