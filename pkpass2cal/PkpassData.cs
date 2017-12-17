using Newtonsoft.Json;
using System.Collections.Generic;

namespace pkpass2cal
{
    public class Barcode
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("messageEncoding")]
        public string MessageEncoding { get; set; }
        [JsonProperty("altText")]
        public string AltText { get; set; }
    }

    public class Location
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("relevantText")]
        public string RelevantText { get; set; }
    }

    public class Field
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class BoardingPass
    {
        [JsonProperty("headerFields")]
        public List<Field> HeaderFields { get; set; }
        [JsonProperty("primaryFields")]
        public List<Field> PrimaryFields { get; set; }
        [JsonProperty("secondaryFields")]
        public List<Field> SecondaryFields { get; set; }
        [JsonProperty("auxiliaryFields")]
        public List<Field> AuxiliaryFields { get; set; }
        [JsonProperty("backFields")]
        public List<Field> BackFields { get; set; }
        [JsonProperty("transitType")]
        public string TransitType { get; set; }
    } 

    public class EventTicket
    {
        [JsonProperty("primaryFields")]
        public List<Field> PrimaryFields { get; set; }
        [JsonProperty("secondaryFields")]
        public List<Field> SecondaryFields { get; set; }
        [JsonProperty("auxiliaryFields")]
        public List<Field> AuxiliaryFields { get; set; }
        [JsonProperty("backFields")]
        public List<Field> BackFields { get; set; }
    }

    public class PkpassData
    {
        [JsonProperty("formatVersion")]
        public int FormatVersion { get; set; }
        [JsonProperty("passTypeIdentifier")]
        public string PassTypeIdentifier { get; set; }
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }
        [JsonProperty("teamIdentifier")]
        public string TeamIdentifier { get; set; }
        [JsonProperty("webServiceURL")]
        public string WebServiceURL { get; set; }
        [JsonProperty("authenticationToken")]
        public string AuthenticationToken { get; set; }
        [JsonProperty("organizationName")]
        public string OrganizationName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("labelColor")]
        public string LabelColor { get; set; }
        [JsonProperty("logoText")]
        public string LogoText { get; set; }
        [JsonProperty("foregroundColor")]
        public string ForegroundColor { get; set; }
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }
        [JsonProperty("barcode")]
        public Barcode Barcode { get; set; }
        [JsonProperty("boardingPass")]
        public BoardingPass BoardingPass { get; set; }
        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }
        [JsonProperty("relevantDate")]
        public string RelevantDate { get; set; }
        [JsonProperty("eventTicket")]
        public EventTicket EventTicket { get; set; }
    }
}
