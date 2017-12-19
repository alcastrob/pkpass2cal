using System.Configuration;

namespace pkpass2cal.Configuration
{
    internal static class Config
    {
        static PkPassProcessorConfigurationSection config = ConfigurationManager.GetSection("pkpassProcessorConfiguration") as PkPassProcessorConfigurationSection;

        internal static PkpassProcessorCollection ProcessorsList
        {
            get
            {
                return config.ProcessorsList;
            }
        }

        internal static CloudServiceConfigurationElement CloudService
        {
            get
            {
                return config.CloudService;
            }
        }

        internal static BannedDomainCollection BannedDomainList
        {
            get
            {
                return config.BannedDomains;
            }
        }
    }
}
