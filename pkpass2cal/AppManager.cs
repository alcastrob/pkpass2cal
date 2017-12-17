using System;

namespace pkpass2cal
{
    internal class AppManager
    {
        internal void ProcessUrl(string url)
        {
            Uri fileUri = new Uri(url);
            IPkpassProcessor processor = PkpassProcessorFactory.CreateByUri(fileUri);
            PkpassData data = processor.DownloadData(fileUri);
            processor.Process(data, fileUri);            
        }

        internal void ProcessFile(string filePath)
        {
            IPkpassProcessor processor = PkpassProcessorFactory.CreateByFile(filePath);
            PkpassData data = processor.GetData(filePath);
            processor.Process(data);
        }
    }
}
