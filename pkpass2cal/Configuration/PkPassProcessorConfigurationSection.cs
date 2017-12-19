using System.Configuration;

namespace pkpass2cal.Configuration
{
    class PkPassProcessorConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("pkpassProcessorList")]
        internal PkpassProcessorCollection ProcessorsList
        {
            get
            {
                return (PkpassProcessorCollection)this["pkpassProcessorList"];
            }
        }

        [ConfigurationProperty("cloudService")]
        internal CloudServiceConfigurationElement CloudService
        {
            get
            {
                return (CloudServiceConfigurationElement)this["cloudService"];
            }
        }

        [ConfigurationProperty("bannedDomains")]
        internal BannedDomainCollection BannedDomains
        {
            get
            {
                return (BannedDomainCollection)this["bannedDomains"];
            }
        }
    }    
}