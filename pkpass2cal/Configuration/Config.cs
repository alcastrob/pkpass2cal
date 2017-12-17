using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.Configuration
{
    public static class Config
    {
        static PkPassProcessorConfigurationSection config = ConfigurationManager.GetSection("pkpassProcessorConfiguration") as PkPassProcessorConfigurationSection;

        public static PkpassProcessorDomainCollection UrlDownloaderList
        {
            get
            {
                return config.UrlDownloaderList;
            }
        }

        public static CloudServiceConfigurationElement CloudService
        {
            get
            {
                return config.CloudService;
            }
        }

        public static PkpassProcessorIssuerCollection PassTypeList
        {
            get
            {
                return config.PassTypeList;
            }
        }
    }
}
