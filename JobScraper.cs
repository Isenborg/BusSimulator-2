using System;
using IronWebScraper;
using System.IO;

namespace BusSimulator
{
    class JobScraper : WebScraper
    {
        string url = "https://foxhugh.com/list-of-lists/list-of-common-jobs/";
        public override void Init()
        {
            if (!File.Exists("c:scrape/Jobs.json"))
            {
                this.LoggingLevel = WebScraper.LogLevel.All;
                this.Request(url, Parse);
            }
            else Console.WriteLine("Jobs Have already been scraped!");
        }

        public override void Parse(Response response)
        {

            foreach (var Jobs_link in response.Css("div p"))
            {
                //save results to file
                Scrape(new ScrapedData() { { "job", Jobs_link.TextContentClean } }, "Jobs.json");
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