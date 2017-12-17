using pkpass2cal.Configuration;
using pkpass2cal.Dropbox;
using System;

namespace pkpass2cal
{
    internal interface IPkpassProcessor
    {
        PkpassData GetData(Uri uri);
        void Process(PkpassData data, Uri fileUri);
        ICloudStorageHelper GetCloudStorage();
    }
}