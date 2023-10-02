using HtmlAgilityPack;

namespace cs_steamscraping
{
    internal class Request
    {
        public async ValueTask<HtmlDocument> GetDocument(string url)
        {
            return await new HtmlWeb().LoadFromWebAsync(url);
        }
    }
}
