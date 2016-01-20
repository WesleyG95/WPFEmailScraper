using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WpfEmailScraper
{
    class LinkScraper
    {
        //Private Class Members
        private HashSet<Uri> _results = new HashSet<Uri>();

        //Public Class Properties
        public HashSet<Uri> Results
        {
            get
            {
                return this._results;
            }
        }

        //Public Methods
        public void Scrape(string url)
        {
            WebClient client = new WebClient();

            try
            {

                HtmlWeb hw = new HtmlWeb();
                HtmlDocument doc = hw.Load(url);

                foreach(HtmlNode match in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    try
                    {
                        this._results.Add(new Uri(match.Attributes["href"].Value));
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {
                //What Should I Do Here?
                //Maybe Nothing for Now
            }
        }
    }
}
