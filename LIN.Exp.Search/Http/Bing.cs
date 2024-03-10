using HtmlAgilityPack;
using LIN.Types.Exp.Search.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LIN.Exp.Search.Http;

internal class Bing
{


    public static async Task<List<SearchResult>> Search(string value)
    {


        string url = "https://www.bing.com/search";

        var ss = await new HttpClient().GetAsync(LIN.Modules.Web.AddParameters(url, new()
        {
            {"q",value },
            {"setlang","es" }
        }));


        var final = await ss.Content.ReadAsStringAsync();

        List<SearchResult> searchResults = BingSearch(final);

        return searchResults;
    }


    static List<SearchResult> BingSearch(string html)
    {

        HtmlDocument doc = new();
        doc.LoadHtml(html);

        var results = new List<SearchResult>();

        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//li[@class='b_algo']"))
        {
            var titleNode = node.SelectSingleNode(".//h2");
            var linkNode = node.SelectSingleNode(".//a[@href]");
            var snippetNode = node.SelectSingleNode(".//p");

            if (titleNode != null && linkNode != null && snippetNode != null)
            {
                string title = titleNode.InnerText.Trim();
                string link = linkNode.GetAttributeValue("href", "");
                string snippet = snippetNode.InnerText.Trim();

                results.Add(new SearchResult(LimpiarTexto( title), link,LimpiarTexto( snippet)));
            }
        }

        return results;
    }


    static string LimpiarTexto(string input)
    {
        // Eliminar etiquetas HTML
        string textoSinEtiquetas = Regex.Replace(input, "<.*?>", string.Empty);

        // Convertir entidades HTML a caracteres legibles
        string textoLimpio = System.Net.WebUtility.HtmlDecode(textoSinEtiquetas);

        return textoLimpio;
    }


}