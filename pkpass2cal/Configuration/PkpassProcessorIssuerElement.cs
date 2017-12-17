using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.Configuration
{
    public class PkpassProcessorIssuerElement : ConfigurationElement
    {
        [ConfigurationProperty("identifierType", IsKey = true, IsRequired = true)]
        public string IdentifierType
        {
            get
            {
                return this["identifierType"].ToString();
            }
        }

        [ConfigurationProperty("type", IsKey = false, IsRequired = true)]
        public string Type
        {
            get
            {
                return this["type"].ToString();
            }
        }

        [ConfigurationProperty("assembly", IsKey = false, IsRequired = false)]
        public string Assembly
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
    }
}
