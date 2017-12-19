using System;

namespace pkpass2cal
{
    internal class AppService
    {
        internal void ProcessUrl(string url)
        {
            Uri fileUri = new Uri(url);
            IPkpassProcessor processor = PkpassProcessorFactory.CreateByUri(fileUri);
            if (processor == null)
            {
                throw new ApplicationException("Link type not supported");
            }
            PkpassData data = processor.DownloadData(fileUri);
            processor.Process(data, fileUri);            
        }

        internal void ProcessFile(string filePath)
        {
            IPkpassProcessor processor = PkpassProcessorFactory.CreateByIssuerViaFile(filePath);
            if (processor == null)
            {
                throw new ApplicationException("File type not supported");
            }
            PkpassData data = processor.GetData(filePath);
            processor.Process(data);
        }
    }
}
