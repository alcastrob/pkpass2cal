using Newtonsoft.Json;

namespace pkpass2cal.Dropbox
{
    internal class Personal
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("host")]
        public long Host { get; set; }
        [JsonProperty("is_team")]
        public bool Is_team { get; set; }
        [JsonProperty("subscription_type")]
        public string Subscription_type { get; set; }
    }

    internal class RootObject
    {
        [JsonProperty("personal")]
        public Personal Personal { get; set; }
    }    
}
