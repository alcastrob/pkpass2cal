using System.Collections.Generic;
using System.Configuration;

namespace pkpass2cal.Configuration
{
    internal class BannedDomainCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BannedDomainElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BannedDomainElement)element).Domain;
        }

        internal BannedDomainElement Get(string identifierType)
        {
            return this.BaseGet(identifierType) as BannedDomainElement;
        }

        internal List<BannedDomainElement> ToList()
        {
            List<BannedDomainElement> returnedValue = new List<BannedDomainElement>();
            for (int counter = 0; counter != this.Count; counter++)
            {
                returnedValue.Add((BannedDomainElement)this.BaseGet(counter));
            }
            return returnedValue;
        }
    }
}

