using System;
using System.Diagnostics;
using Flurl;

namespace pkpass2cal
{
    public class GCalManager
    {
        public static void CreateAppoiment(string title, DateTime start, DateTime end, string location, string url)
        {
            var composedUrl = "http://www.google.com/calendar/event"
                .SetQueryParams(new
                    {
                        action = "TEMPLATE",
                        sprop = "website:" + url,
                        details = url,
                        dates = start.ToUniversalTime().ToString("yyyyMMddTHHmmssZ") + "/" + end.ToUniversalTime().ToString("yyyyMMddTHHmmssZ")
                    })
                .SetQueryParam("location", location.Replace(' ', '+'), true)
                .SetQueryParam("text", title.Replace(' ', '+'), true) ;

            Process.Start(composedUrl);
        }
    }
}
