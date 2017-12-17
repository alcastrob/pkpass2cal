using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.Configuration
{
    public class PkpassProcessorDomainCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PkpassProcessorDomainElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PkpassProcessorDomainElement)element).Domain;
        }

        public PkpassProcessorDomainElement Get(string domain)
        {
            return this.BaseGet(domain) as PkpassProcessorDomainElement;
        }
    }
}
