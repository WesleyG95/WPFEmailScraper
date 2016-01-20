using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace WpfEmailScraper
{
    class EmailScraper
    {
        //Private Class Members
        private HashSet<MailAddress> _results = new HashSet<MailAddress>();

        //Public Class Properties
        public HashSet<MailAddress> Results
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
                string result = client.DownloadString(url);

                //Use A Search To Find Emails In Result
                Regex regex = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(result);

                //Store Found Emails In The Results
                foreach (Match match in matches)
                {
                    this._results.Add(new MailAddress(match.Value));
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
