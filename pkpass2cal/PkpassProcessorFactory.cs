using pkpass2cal.Configuration;
using pkpass2cal.Dropbox;
using System;
using System.Configuration;

namespace pkpass2cal
{
    internal class PkpassProcessorFactory
    {
        public static IPkpassProcessor CreateByUri(Uri uri)
        {
            var configData = Config.UrlDownloaderList.Get(uri.Host);        
            IPkpassProcessor returnedValue = (IPkpassProcessor)Activator.CreateInstance(configData.Assembly, configData.Type).Unwrap();
            
            return returnedValue;
        }
    }
}