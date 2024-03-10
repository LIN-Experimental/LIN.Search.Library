namespace LIN.Exp.Search.Http;


internal class Bing
{

    /// <summary>
    /// Consulta a la API de Bing.
    /// </summary>
    /// <param name="value">Consulta.</param>
    public static async Task<List<SearchResult>> Search(string value)
    {

        // Url base.
        string url = "https://www.bing.com/search";

        // Cliente.
        HttpClient client = new();

        // Parámetros.
        url = LIN.Modules.Web.AddParameters(url, new()
        {
            {"q", value },
            {"setlang", "es" }
        });

        // Respuesta HTTP.
        var response = await client.GetAsync(url);

        // Contenido.
        string content = await response.Content.ReadAsStringAsync();

        // Convertir a objeto.
        var searchResults = Services.Parsers.Convert(content);

        // Retornar.
        return searchResults;

    }


    
    


}