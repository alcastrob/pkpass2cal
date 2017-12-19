using System.Configuration;

namespace pkpass2cal.Configuration
{
    internal class PkpassProcessorElement : ConfigurationElement
    {
        [ConfigurationProperty("domain", IsKey = true, IsRequired = false)]
        internal string Domain
        {
            get
            {
                return this["domain"].ToString();
            }
        }

        [ConfigurationProperty("type", IsKey = false, IsRequired = true)]
        internal string Type
        {
            get
            {
                return this["type"].ToString();
            }
        }

        [ConfigurationProperty("assembly", IsKey = false, IsRequired = false)]
        internal string Assembly
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this["assembly"].ToString()))
                {
                    return this["assembly"].ToString();
                }
                else
                {
                    return System.Reflection.Assembly.GetExecutingAssembly().FullName;
                }
            }
        }

        [ConfigurationProperty("identifierType", IsKey = true, IsRequired = false)]
        internal string IdentifierType
        {
            get
            {
                return this["identifierType"].ToString();
            }
        }
    }
}
