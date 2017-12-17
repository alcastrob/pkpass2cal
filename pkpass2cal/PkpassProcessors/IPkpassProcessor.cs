using pkpass2cal.Configuration;
using System;

namespace pkpass2cal
{
    internal interface IPkpassProcessor
    {
        PkpassData GetData(Uri uri);
        void Process(PkpassData data, Uri fileUri);
    }
}