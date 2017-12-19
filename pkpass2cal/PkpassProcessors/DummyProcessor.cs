using pkpass2cal.CloudServices;
using pkpass2cal.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.PkpassProcessors
{
    /// <summary>
    /// Generic processor. To be used for example with links in gmail messages.
    /// </summary>
    public class DummyProcessor : IPkpassProcessor
    {
        ICloudStorageHelper cloudStorageHelper;

        public DummyProcessor()
        {
            cloudStorageHelper = CloudServiceFactory.CreateCloudService();
        }

        public PkpassData DownloadData(Uri uri)
        {
            string destinationFileName = cloudStorageHelper.GetHomePath() + Config.CloudService.LocalDirectory + Guid.NewGuid() + ".pkpass";
            FileDownloader.DownloadFile(uri.AbsoluteUri, destinationFileName);
            try
            {
                return PkpassManager.OpenPkpass(destinationFileName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problems opening the pkpass file", ex);
            }
        }

        public PkpassData GetData(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Process(PkpassData data, Uri fileUri)
        {
            throw new NotImplementedException();
        }

        public void Process(PkpassData data)
        {
            throw new NotImplementedException();
        }
    }
}
