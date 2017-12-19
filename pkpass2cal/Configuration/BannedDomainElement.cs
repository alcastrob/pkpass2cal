using System.Configuration;

namespace pkpass2cal.Configuration
{
    internal class BannedDomainElement : ConfigurationElement
    {
        [ConfigurationProperty("domain", IsKey = true, IsRequired = false)]
        internal string Domain
        {
            get
            {
                return this["domain"].ToString();
            }
        }
    }
}