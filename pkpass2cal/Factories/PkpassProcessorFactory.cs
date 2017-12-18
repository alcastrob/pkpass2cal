using pkpass2cal.Configuration;
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

        public static IPkpassProcessor CreateByFile(string filePath)
        {
            var pass = PkpassManager.OpenPkpass(filePath);            
            var configData = Config.PassTypeList.Get(pass.PassTypeIdentifier);
            IPkpassProcessor returnedValue = (IPkpassProcessor)Activator.CreateInstance(configData.Assembly, configData.Type).Unwrap();
            return returnedValue;
        }
    }
}