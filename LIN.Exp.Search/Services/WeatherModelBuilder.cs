using LIN.Exp.Search.Models.Weather;
using LIN.Types.Exp.Search.Enums;

namespace LIN.Exp.Search.Services;

internal class WeatherModelBuilder
{


    public static LIN.Types.Exp.Search.Models.Weather? Build(WeatherData? data)
    {

        if (data == null)
            return null;


        var weather = new Types.Exp.Search.Models.Weather
        {
            CityName = data.Name,
            Latitude = data.Coord.Lat,
            Longitude = data.Coord.Lon,
            Temperature = new()
            {
                Feels = data.Main.Feels_like,
                Humidity = data.Main.Humidity,
                Max = data.Main.Temp_max,
                Min = data.Main.Temp_min,
                Pressure = data.Main.Pressure,
                Value = data.Main.Temp
            },
            Wind = new()
            {
                Speed = data.Wind.Speed
            },


        };


        string main = data.Weather[0].Main.Trim().ToLower();
        string description = data.Weather[0].Description.Trim().ToLower();

        switch (main)
        {
            case "thunderstorm":
                weather.Condition = Condition.ThunderStorm;
                break;

            case "drizzle":
                weather.Condition = Condition.Drizzle;
                break;

            case "rain":
                weather.Condition = Condition.Rain;
                break;

            case "snow":
                weather.Condition = Condition.Snow;
                break;

            case "mist":
                weather.Condition = Condition.Mist;
                break;

            case "smoke":
                weather.Condition = Condition.Smoke;
                break;

            case "haze":
                weather.Condition = Condition.Haze;
                break;

            case "dust":
                weather.Condition = Condition.Dust;
                break;

            case "fog":
                weather.Condition = Condition.Fog;
                break;

            case "sand":
                weather.Condition = Condition.Sand;
                break;

            case "ash":
                weather.Condition = Condition.Ash;
                break;

            case "squall":
                weather.Condition = Condition.Squall;
                break;

            case "tornado":
                weather.Condition = Condition.Tornado;
                break;


            case "clear":
                weather.Condition = Condition.Clear;
                break;

            case "clouds":

                if (description == "few clouds")
                    weather.Condition = Condition.FewClouds;
                else if (description == "scattered clouds")
                    weather.Condition = Condition.ScatteredClouds;
                else if (description == "broken cloud")
                    weather.Condition = Condition.BrokenClouds;
                else if (description == "overcast clouds")
                    weather.Condition = Condition.OvercastClouds;
                else
                    weather.Condition = Condition.ScatteredClouds;

                break;

        }





        return weather;

    }

}