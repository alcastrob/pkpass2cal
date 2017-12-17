using Newtonsoft.Json;
using System;
using System.IO;

namespace pkpass2cal.Dropbox
{
    public class DropboxHelper : ICloudStorageHelper
    {
        public string GetHomePath()
        {
            string infoJsonPath = Environment.ExpandEnvironmentVariables(@"%APPDATA%\Dropbox\info.json");

            if (!File.Exists(infoJsonPath))
            {
                infoJsonPath = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%\Dropbox\info.json");
                if (!File.Exists(infoJsonPath))
                { 
                    throw new ApplicationException("Dropbox configuration not found");
                }
            }

            return JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(infoJsonPath)).Personal.Path;
        }
    }
}
