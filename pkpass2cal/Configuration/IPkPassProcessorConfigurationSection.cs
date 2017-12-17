using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal.Configuration
{
    public interface IPkPassProcessorConfigurationSection
    {
        PkpassProcessorCollection UrlDownloaderList { get; }
        string CloudDirectory { get; }
    }
}
