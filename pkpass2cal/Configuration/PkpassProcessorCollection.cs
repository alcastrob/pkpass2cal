using System.Collections.Generic;
using System.Configuration;

namespace pkpass2cal.Configuration
{
    internal class PkpassProcessorCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PkpassProcessorElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PkpassProcessorElement)element).IdentifierType;
        }

        internal PkpassProcessorElement Get(string identifierType)
        {
            return this.BaseGet(identifierType) as PkpassProcessorElement;
        }

        internal List<PkpassProcessorElement> ToList()
        {
            List<PkpassProcessorElement> returnedValue = new List<PkpassProcessorElement>();
            for (int counter = 0; counter != this.Count; counter++)
            {
                returnedValue.Add((PkpassProcessorElement)this.BaseGet(counter));
            }
            return returnedValue;
        }
    }
}
