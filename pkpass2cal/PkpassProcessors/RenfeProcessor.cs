using pkpass2cal.CloudServices;
using pkpass2cal.Configuration;
using System;
using System.Collections.Generic;
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

        public virtual PkpassData GetData(Uri uri)
        {
            string fileName = cloudStorageHelper.GetHomePath() + Config.CloudService.LocalDirectory + uri.Query.Split(new char[] { '/' }).Last();
            //https://venta.renfe.com/vol/passbookEmail.do?pkpass=2017-12-26/MKH2KS0CNH34N9B5XE56OM.pkpass
            string fileUrl = "https://w4.renfe.es/passbook/" + uri.Query.Split(new char[] { '=' }).Last();
            FileDownloader.DownloadFile(fileUrl, fileName);
            return PkpassManager.OpenPkpass(fileName);
        }

        public virtual void Process(PkpassData data, Uri uri)
        {
            var passanger = data.boardingPass.backFields.First(p => p.Key == "nombrepasajero").Value;

            string title = "AVE a " + data.boardingPass.primaryFields.First(p => p.Key == "destino").Label;

            var startTime = ConvertDateTime(data.boardingPass.headerFields.First(p => p.Key == "destinofecha").Value,
                data.boardingPass.primaryFields.First(p => p.Key == "boardingTime").Value);

            var endTime = ConvertDateTime(data.boardingPass.headerFields.First(p => p.Key == "destinofecha").Value,
                data.boardingPass.primaryFields.First(p => p.Key == "destino").Value);

            var location = data.boardingPass.primaryFields.First(p => p.Key == "boardingTime").Label;
            GCalManager.CreateAppoiment(title, startTime, endTime, string.Empty, uri.AbsoluteUri);
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
