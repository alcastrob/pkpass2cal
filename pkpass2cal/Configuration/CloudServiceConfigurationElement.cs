using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.Configuration
{
    public class CloudServiceConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("localDirectory", IsRequired = true)]
        public string LocalDirectory
        {
            get
            {
                return this["localDirectory"].ToString();
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
                if (!string.IsNullOrWhiteSpace(this["assembly"].ToString()))
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
