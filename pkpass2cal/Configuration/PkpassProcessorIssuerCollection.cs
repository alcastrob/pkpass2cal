using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.Configuration
{
    public class PkpassProcessorIssuerCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PkpassProcessorIssuerElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PkpassProcessorIssuerElement)element).IdentifierType;
        }

        public PkpassProcessorIssuerElement Get(string domain)
        {
            return this.BaseGet(domain) as PkpassProcessorIssuerElement;
        }
    }
}
