using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal
{
    public class GCalManager
    {
        public static void CreateAppoiment(string title, DateTime start, DateTime end, string location, string url)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(@"http://www.google.com/calendar/event?");
            sb.Append($"location={WebUtility.UrlEncode(location)}");
            sb.Append(@"&action=TEMPLATE");
            sb.Append($"&sprop=website%3A{WebUtility.UrlEncode(url)}");            
            sb.Append($"&text={WebUtility.UrlEncode(title)}");
            sb.Append($"&details={url}");
            sb.Append($"&dates={start.ToUniversalTime().ToString("yyyyMMddTHHmmssZ")}%2F{end.ToUniversalTime().ToString("yyyyMMddTHHmmssZ")}");

            Process.Start(sb.ToString());            
        }
    }
}
