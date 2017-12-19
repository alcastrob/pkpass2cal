using pkpass2cal.Configuration;
using pkpass2cal.PkpassProcessors;
using System;
using System.Configuration;
using System.Linq;

namespace pkpass2cal
{
    internal class PkpassProcessorFactory
    {
        internal static IPkpassProcessor CreateByUri(Uri uri)
        {
            PkpassProcessorElement configData = null;

            var matchWithHost = Config.ProcessorsList.ToList().Where(p => p.Domain == uri.Host);
            if (matchWithHost.Count() > 0)
            {
                configData = matchWithHost.First();                
            }
            else
            {
                // No match by domain. Let's see first if the uri comes from a banned domain.
                if (Config.BannedDomainList.Get(uri.Host) != null)
                {
                    return null;
                }
                else
                {
                    // So let's look inside the pkpass for the issuer.                    
                    PkpassData pkpass = new DummyProcessor().DownloadData(uri);
                    configData = Config.ProcessorsList.Get(pkpass.PassTypeIdentifier);
                }
            }

            IPkpassProcessor returnedValue = (IPkpassProcessor)Activator.CreateInstance(configData.Assembly, configData.Type).Unwrap();            
            return returnedValue;
        }

        internal static IPkpassProcessor CreateByIssuerViaFile(string filePath)
        {
            var pass = PkpassManager.OpenPkpass(filePath);
            var configData = Config.ProcessorsList.Get(pass.PassTypeIdentifier);
            IPkpassProcessor returnedValue = (IPkpassProcessor)Activator.CreateInstance(configData.Assembly, configData.Type).Unwrap();
            return returnedValue;
        }
    }
}