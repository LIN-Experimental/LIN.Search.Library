using System;

namespace LIN.Exp.Search.Services;


internal class Parsers
{

    /// <summary>
    /// Limpiar un texto.
    /// </summary>
    /// <param name="input">Entrada.</param>
    public static string CleanHtml(string input)
    {
        // Eliminar etiquetas HTML
        string textoSinEtiquetas = Regex.Replace(input, "<.*?>", string.Empty);

        // Convertir entidades HTML a caracteres legibles
        string textoLimpio = System.Net.WebUtility.HtmlDecode(textoSinEtiquetas);

        return textoLimpio;
    }



    /// <summary>
    /// Convertir la entrada HTML en SearchResult.
    /// </summary>
    /// <param name="html">Html.</param>
    public static List<SearchResult> Convert(string html)
    {

        try
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

                    results.Add(new SearchResult(CleanHtml(title), link, CleanHtml(snippet))
                    {
                        ResultType = Types.Exp.Search.Enums.ResultType.Web
                    });
                }
            }

            return results;

        }
        catch (Exception)
        {

        }
        return [];

    }


}
