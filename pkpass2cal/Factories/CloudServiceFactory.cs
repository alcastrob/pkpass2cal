using pkpass2cal.CloudServices;
using pkpass2cal.Configuration;
using System;

namespace pkpass2cal
{
    internal class CloudServiceFactory
    {
        public static ICloudStorageHelper CreateCloudService()
        {
            ICloudStorageHelper returnedValue = (ICloudStorageHelper)Activator.CreateInstance(Config.CloudService.Assembly, Config.CloudService.Type).Unwrap();
            return returnedValue;
        }
    }
}
