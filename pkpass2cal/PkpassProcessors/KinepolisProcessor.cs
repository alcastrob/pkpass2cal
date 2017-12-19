using pkpass2cal.CloudServices;
using pkpass2cal.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.PkpassProcessors
{
    public class KinepolisProcessor : IPkpassProcessor
    {
        ICloudStorageHelper cloudStorageHelper;

        public KinepolisProcessor()
        {
            cloudStorageHelper = CloudServiceFactory.CreateCloudService();
        }

        public virtual PkpassData DownloadData(Uri uri)
        {
            string destinationFileName = cloudStorageHelper.GetHomePath() + Config.CloudService.LocalDirectory + uri.Query.Split(new char[] { '/' }).Last();
            FileDownloader.DownloadFile(uri.AbsoluteUri, destinationFileName);
            return PkpassManager.OpenPkpass(destinationFileName);
        }

        public PkpassData GetData(string filePath)
        {
            Path.GetFileName(filePath);
            string destinationFileName = cloudStorageHelper.GetHomePath() + Config.CloudService.LocalDirectory + Path.GetFileName(filePath);
            
            //Only if they are in different paths we do the copy
            if (destinationFileName != filePath && !File.Exists(destinationFileName))
                File.Copy(filePath, destinationFileName);

            return PkpassManager.OpenPkpass(destinationFileName);
        }

        public virtual void Process(PkpassData data, Uri uri)
        {            
            var parsedData = ParseData(data);
            GCalManager.CreateAppoiment(parsedData.Item1, parsedData.Item2, parsedData.Item3, parsedData.Item4, uri.AbsoluteUri);
        }

        public virtual void Process(PkpassData data)
        {
            var parsedData = ParseData(data);
            GCalManager.CreateAppoiment(parsedData.Item1, parsedData.Item2, parsedData.Item3, parsedData.Item4, string.Empty);
        }

        private (string, DateTime, DateTime, string) ParseData(PkpassData data)
        {
            string title = data.EventTicket.PrimaryFields.First(t => t.Key == "EVENTNAME").Value;
            DateTime startTime = DateTime.Parse(data.RelevantDate);
            DateTime endTime = startTime.AddHours(2.5); //By default
            var location = $"{data.OrganizationName} {data.LogoText}";

            return (title, startTime, endTime, location);
        }
    }
}
