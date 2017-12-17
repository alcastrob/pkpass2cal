using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal
{
    class FileDownloader
    {
        /// <summary>
        /// Download a pkpass into the local filesystem
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        public static void DownloadFile(string url, string fileName)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.UserAgent = "user-agent:Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";

                HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebReponse.GetResponseStream();
                using (var fileStream = File.Create(fileName))
                {
                    stream.CopyTo(fileStream);
                }
            }
            catch (Exception)
            { }
        }
    }
}
