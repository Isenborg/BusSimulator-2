using System;
using Newtonsoft;
using IronWebScraper;
using System.IO;

namespace BusSimulator
{
    public class NameScraper : WebScraper
    {
        string url = "https://svenskanamn.alltforforaldrar.se/namn/namntoppen/2000";
        public override void Init()
        {
            if (!File.Exists("c:scrape/Names.json"))
            {
                this.LoggingLevel = WebScraper.LogLevel.All;
                this.Request(url, Parse);
            }
            else Console.WriteLine("Names Have already been scraped!");
        }

        public override void Parse(Response response)
        {

            foreach (var Name_link in response.Css("table u"))
            {
                //save results to file
                Scrape(new ScrapedData() { { "name", Name_link.TextContentClean } }, "Names.json");
            }
            if (response.CssExists("div.prev-post > a[href]"))
            {
                // Get Link URL
                var next_page = response.Css("div.prev-post > a[href]")[0].Attributes["href"];
                // Scrape Next URL
                this.Request(next_page, Parse);
            }
        }
    }
}