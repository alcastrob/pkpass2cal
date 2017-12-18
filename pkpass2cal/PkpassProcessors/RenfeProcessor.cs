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
    public class RenfeProcessor : IPkpassProcessor
    {
        ICloudStorageHelper cloudStorageHelper;

        public RenfeProcessor()
        {
            cloudStorageHelper = CloudServiceFactory.CreateCloudService();
        }

        public virtual PkpassData DownloadData(Uri uri)
        {
            string fileName = cloudStorageHelper.GetHomePath() + Config.CloudService.LocalDirectory + uri.Query.Split(new char[] { '/' }).Last();
            //https://venta.renfe.com/vol/passbookEmail.do?pkpass=2017-12-26/MKH2KS0CNH34N9B5XE56OM.pkpass
            string fileUrl = "https://w4.renfe.es/passbook/" + uri.Query.Split(new char[] { '=' }).Last();
            FileDownloader.DownloadFile(fileUrl, fileName);
            return PkpassManager.OpenPkpass(fileName);
        }

        public PkpassData GetData(string filePath)
        {
            Path.GetFileName(filePath);
            string fileName = cloudStorageHelper.GetHomePath() + Config.CloudService.LocalDirectory + Path.GetFileName(filePath);
            
            //Only if they are in different paths we do the copy
            if (fileName != filePath)
                File.Copy(filePath, fileName);

            return PkpassManager.OpenPkpass(fileName);
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
            string title = "AVE a " + data.BoardingPass.PrimaryFields.First(p => p.Key == "destino").Label;
            DateTime startTime = ConvertDateTime(data.BoardingPass.HeaderFields.First(p => p.Key == "destinofecha").Value,
                data.BoardingPass.PrimaryFields.First(p => p.Key == "boardingTime").Value);
            DateTime endTime = ConvertDateTime(data.BoardingPass.HeaderFields.First(p => p.Key == "destinofecha").Value,
                data.BoardingPass.PrimaryFields.First(p => p.Key == "destino").Value);
            var location = data.BoardingPass.PrimaryFields.First(p => p.Key == "boardingTime").Label;

            return (title, startTime, endTime, location);
        }

        protected DateTime ConvertDateTime(string date, string time)
        {
            string[] dateParts = date.Split(new char[] { '/' });
            string[] timeParts = time.Split(new char[] { ':' });

            DateTime returnedValue = new DateTime(Convert.ToInt32(dateParts[2]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[0]),
                Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]), 0);
            return returnedValue;
        }       
    }
}
