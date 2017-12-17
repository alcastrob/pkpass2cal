using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal
{
    internal class PkpassManager
    {
        public static PkpassData OpenPkpass(string filePath)
        {
            using (var file = File.OpenRead(filePath))
            {
                using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
                {
                    var json = zip.Entries.First(p => p.Name == "pass.json");
                    using (var stream = json.Open())
                    {
                        StreamReader reader = new StreamReader(stream);
                        var content = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<PkpassData>(content);
                    }                        
                }
            }
        }
    }
}
