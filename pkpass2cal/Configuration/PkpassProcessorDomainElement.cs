using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.Configuration
{
    public class PkpassProcessorDomainElement : ConfigurationElement
    {
        [ConfigurationProperty("domain", IsKey = true, IsRequired = true)]
        public string Domain
        {
            get
            {
                return this["domain"].ToString();
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
