# Cliente de OpenWeather y Microsoft Bing

Esta biblioteca permite conectar con los servicios de tiempo y bing.

## Bing

Permite obtener los resultados de busqueda de Bing y mapearlos con .NET

* No necesita una API Key.

```csharp
static async Task Main()
{

    // Query.
    string query = "Bill Gates";
    
    // Obtener información.
    List<SearchResult> searchResponse = await LIN.Exp.Search.Client.Search(query);

    // Recorrer.
    foreach (SearchResult result in searchResponse)
    {
        Console.WriteLine($"- {result.Title}");
        Console.WriteLine($"- {result.Link}");
        Console.WriteLine($"{result.Snippet}");
    }

}
```

### ¿Porque funciona?

Para recuperar la informacion se hace webscraping a la pagina de Bing.




## Open Weather

Permite obtener la información del tiempo de una ciudad / region.

* SI necesita una API Key.

```csharp
static async Task Main()
{

    // Establecer la llave.
    LIN.Exp.Search.Client.SetWeatherApi("API KEY");

    // Ciudad.
    string city = "Medellin";

    // Obtener información.
    var weatherResponse = await LIN.Exp.Search.Client.GetWeatherAsync(city);

    // Validar.
    if (weatherResponse == null)
    {
        Console.WriteLine($"No se econtro informacion de '{city}'");
    }

    // Mostrar la información.

    Console.WriteLine(weatherResponse.CityName); // Nombre de la ciudad.
    Console.WriteLine(weatherResponse.Latitude); // Latitud.
    Console.WriteLine(weatherResponse.Longitude); // Longitud.
    Console.WriteLine(weatherResponse.Condition); // Condición del tiempo.
    Console.WriteLine(weatherResponse.Wind.Speed); // Velocidad del tiempo.
    Console.WriteLine(weatherResponse.Temperature.Value); // Temperatura actual.
    Console.WriteLine(weatherResponse.Temperature.Feels); // Sensación termica.
    Console.WriteLine(weatherResponse.Temperature.Min); // Temperatura minima
    Console.WriteLine(weatherResponse.Temperature.Max); // Temperature maxima
    Console.WriteLine(weatherResponse.Temperature.Pressure); // Presión.
    Console.WriteLine(weatherResponse.Temperature.Humidity); // Humedad.

}
```

### ¿Porque funciona?

Para recuperar la información se consulta la API de Open Weather original.