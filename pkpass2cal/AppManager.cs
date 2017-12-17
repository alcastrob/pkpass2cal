using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal
{
    internal class AppManager
    {
        internal void ProcessUrl(string url)
        {
            Uri fileUri = new Uri(url);
            IPkpassProcessor processor = PkpassProcessorFactory.CreateByUri(fileUri);
            PkpassData data = processor.GetData(fileUri);
            processor.Process(data, fileUri);            
        }

        internal void ProcessFile(string file)
        {
            throw new NotImplementedException();
        }

        
    }
}
