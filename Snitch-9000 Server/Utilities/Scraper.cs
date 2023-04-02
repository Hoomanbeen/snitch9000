using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using snitch_9000.Models;
using snitch_9000.Data;

namespace snitch_9000.Utilities
{
    public class Scraper
    {
        public static ICollection<Hit> GetHits(string query)
        {
            ICollection<Hit> hits = new List<Hit>();
            ICollection<String> urls = new List<String>();

            string googleUrl = "http://google.com/search?q=" + WebUtility.UrlEncode(query);
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "user-agent=Mozilla/5.0" +
                    " (Windows NT 10.0; Win64; x64)" +
                    " AppleWebKit/537.36 (KHTML, like Gecko)" +
                    " Chrome/74.0.3729.169 Safari/537.36";

            var htmlDoc = web.Load(googleUrl);
            HtmlNodeCollection allNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='yuRUbf']");

            foreach (var tag in allNodes)
            {
                string anchor = tag.FirstChild.Attributes["href"].Value;
                // string desc = tag.ParentNode.ParentNode.ChildNodes[1].InnerText;
                // string title = tag.Descendants("h3").FirstOrDefault().InnerText;

                if (anchor.Contains("chegg.com") || anchor.Contains("coursehero.com"))
                {
                    //Console.WriteLine(tag);
                    var hit = new Hit();
                    hit.link = anchor;

                    if (!urls.Contains(hit.link))
                    {
                        urls.Add(hit.link);
                        hits.Add(hit);
                    }

                }
            }

            return hits;
        }
    }
}