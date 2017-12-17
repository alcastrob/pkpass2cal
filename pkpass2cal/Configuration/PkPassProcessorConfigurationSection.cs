using System.Configuration;

namespace pkpass2cal.Configuration
{
    class PkPassProcessorConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("pkpassProcessorDomainList")]
        public PkpassProcessorDomainCollection UrlDownloaderList
        {
            get
            {
                return (PkpassProcessorDomainCollection)this["pkpassProcessorDomainList"];
            }
        }

        [ConfigurationProperty("cloudService")]
        public CloudServiceConfigurationElement CloudService
        {
            get
            {
                return (CloudServiceConfigurationElement)this["cloudService"];
            }
        }

        [ConfigurationProperty("pkpassProcessorIssuerList")]
        public PkpassProcessorIssuerCollection PassTypeList
        {
            get
            {
                return (PkpassProcessorIssuerCollection)this["pkpassProcessorIssuerList"];
            }
        }
    }    
}