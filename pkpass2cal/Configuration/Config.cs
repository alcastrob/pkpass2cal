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

        public static PkpassProcessorCollection UrlDownloaderList
        {
            get
            {
                return config.UrlDownloaderList;
            }
        }

        public static CloudService CloudService
        {
            get
            {
                return config.CloudService;
            }
        }
    }
}
