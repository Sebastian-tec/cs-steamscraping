using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cs_steamscraping
{
    internal class Request
    {
        public async ValueTask<HtmlDocument> GetWebRequest(string url)
        {
            return await new HtmlWeb().LoadFromWebAsync(url);
        }
    }
}
