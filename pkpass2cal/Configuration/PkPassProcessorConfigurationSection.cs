using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace pkpass2cal.Configuration
{
    class PkPassProcessorConfigurationSection : ConfigurationSection/*, IPkPassProcessorConfigurationSection*/
    {
        [ConfigurationProperty("pkpassProcessorList")]
        public PkpassProcessorCollection UrlDownloaderList
        {
            get
            {
                return (PkpassProcessorCollection)this["pkpassProcessorList"];
            }
        }

        [ConfigurationProperty("cloudService")]
        public CloudService CloudService
        {
            get
            {
                return (CloudService)this["cloudService"];
            }
        }
    }

    public class CloudService : ConfigurationElement
    {
        [ConfigurationProperty("localDirectory", IsRequired = true)]
        public string LocalDirectory
        {
            get
            {
                return this["localDirectory"].ToString();
            }
        }
    }

    public class PkpassProcessorCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PkpassProcessorElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PkpassProcessorElement)element).Domain;
        }

        public PkpassProcessorElement Get(string domain)
        {
            return this.BaseGet(domain) as PkpassProcessorElement;
        }
    }

    public class PkpassProcessorElement : ConfigurationElement
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
                return this["assembly"].ToString();
            }
        }
    }
}