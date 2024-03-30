using System;

namespace LIN.Exp.Search.Http;


internal class Bing
{

    /// <summary>
    /// Consulta a la API de Bing.
    /// </summary>
    /// <param name="value">Consulta.</param>
    public static async Task<List<SearchResult>> Search(string value)
    {

        // Cliente.
        Global.Http.Services.Client client = new()
        {
            BaseAddress = new Uri("https://www.bing.com/search"),
            TimeOut = 7
        };

        // Parámetros.
        client.AddParameter("q", value.ToLower());
        client.AddParameter("setlang","es");

        // Respuesta.
        var response = await client.Get();

        // Convertir a objeto.
        var searchResults = Services.Parsers.Convert(response);

        // Retornar.
        return searchResults;

    }






}