using Newtonsoft.Json;
using System.Collections.Generic;

namespace pkpass2cal
{
    /// <summary>
    /// Barcode Dictionary Keys
    /// </summary>
    public class Barcode
    {
        [JsonProperty("altText")]
        public string AltText { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }        
        [JsonProperty("messageEncoding")]
        public string MessageEncoding { get; set; }        
    }

    /// <summary>
    /// Beacon Dictionaty Keys
    /// </summary>
    public class Beacon
    {
        [JsonProperty("major")]
        public int Major { get; set; }
        [JsonProperty("minor")]
        public int Minor { get; set; }
        [JsonProperty("proximityUUID")]
        public string ProximityUUID { get; set; }
        [JsonProperty("relevantText")]
        public string RelevantText { get; set; }
    }

    /// <summary>
    /// Location Dictionary Keys
    /// </summary>
    public class Location
    {
        [JsonProperty("altitude")]
        public double Altitude { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("relevantText")]
        public string RelevantText { get; set; }
    }

    /// <summary>
    /// Standard Field Dictionary Keys
    /// </summary>
    public class Field
    {
        [JsonProperty("attributedValue")]
        public string AttributedValue { get; set; }
        [JsonProperty("changeMessage")]
        public string ChangeMessage { get; set; }
        [JsonProperty("dataDetectorTypes")]
        public List<string> DataDetectorTypes { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("textAlignment")]
        public string TextAlignment { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    /// <summary>
    /// Pass Structrue Dictionary Keys
    /// </summary>
    public class Pass
    {
        [JsonProperty("auxiliaryFields")]
        public List<Field> AuxiliaryFields { get; set; }
        [JsonProperty("backFields")]
        public List<Field> BackFields { get; set; }
        [JsonProperty("headerFields")]
        public List<Field> HeaderFields { get; set; }
        [JsonProperty("primaryFields")]
        public List<Field> PrimaryFields { get; set; }
        [JsonProperty("secondaryFields")]
        public List<Field> SecondaryFields { get; set; }                
        [JsonProperty("transitType")]
        public string TransitType { get; set; }
    }

    /// <summary>
    /// Definition of the pass.json file, as described in https://developer.apple.com/library/content/documentation/UserExperience/Reference/PassKit_Bundle/Chapters/Introduction.html#//apple_ref/doc/uid/TP40012026-CH0-SW1
    /// </summary>
    public class PkpassData
    {
        //Standard keys
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("formatVersion")]
        public int FormatVersion { get; set; }
        [JsonProperty("organizationName")]
        public string OrganizationName { get; set; }
        [JsonProperty("passTypeIdentifier")]
        public string PassTypeIdentifier { get; set; }
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }
        [JsonProperty("teamIdentifier")]
        public string TeamIdentifier { get; set; }

        //Associated App Keys
        [JsonProperty("appLaunchURL")]
        public string AppLaunchURL { get; set; }
        [JsonProperty("associatedStoreIdentifiers")]
        public List<int> AssociatedStoreIdentifiers { get; set; }

        //Companion App Keys
        [JsonProperty("userInfo")]
        public string UserInfo { get; set; }

        //Expiration Keys
        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }
        [JsonProperty("voided")]
        public bool Voided { get; set; }

        //Relevance Keys
        [JsonProperty("beacons")]
        public List<Beacon> Beacons { get; set; }
        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }
        [JsonProperty("maxDistance")]
        public double MaxDistance { get; set; }
        [JsonProperty("relevantDate")]
        public string RelevantDate { get; set; }

        //Style Keys
        [JsonProperty("boardingPass")]
        public Pass BoardingPass { get; set; }
        [JsonProperty("coupon")]
        public Pass Coupon { get; set; }
        [JsonProperty("eventTicket")]
        public Pass EventTicket { get; set; }
        [JsonProperty("generic")]
        public Pass Generic { get; set; }
        [JsonProperty("storeCard")]
        public Pass StoreCard { get; set; }

        //Visual Apperance Keys
        [JsonProperty("barcode")]
        public Barcode Barcode { get; set; }
        [JsonProperty("barcodes")]
        public List<Barcode> Barcodes { get; set; }
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }
        [JsonProperty("foregroundColor")]
        public string ForegroundColor { get; set; }
        [JsonProperty("groupingIdentifier")]
        public string GroupingIdentifier { get; set; }
        [JsonProperty("labelColor")]
        public string LabelColor { get; set; }
        [JsonProperty("logoText")]
        public string LogoText { get; set; }
        [JsonProperty("suppressStripShine")]
        public bool SuppressStripShine { get; set; }

        //Web Service Keys
        [JsonProperty("authenticationToken")]
        public string AuthenticationToken { get; set; }
        [JsonProperty("webServiceURL")]
        public string WebServiceURL { get; set; }
    }
}
