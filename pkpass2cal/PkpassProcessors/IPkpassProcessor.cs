using pkpass2cal.Configuration;
using System;

namespace pkpass2cal
{
    internal interface IPkpassProcessor
    {
        PkpassData DownloadData(Uri uri);
        PkpassData GetData(string filePath);
        void Process(PkpassData data, Uri fileUri);
        void Process(PkpassData data);
    }
}