using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkpass2cal
{
    public class Barcode
    {
        public string message { get; set; }
        public string format { get; set; }
        public string messageEncoding { get; set; }
        public string altText { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string relevantText { get; set; }
    }

    //public class HeaderField
    //{
    //    public string key { get; set; }
    //    public string label { get; set; }
    //    public string value { get; set; }
    //}

    //public class PrimaryField
    //{
    //    public string key { get; set; }
    //    public string label { get; set; }
    //    public string value { get; set; }
    //    public string changeMessage { get; set; }
    //}

    //public class SecondaryField
    //{
    //    public string key { get; set; }
    //    public string label { get; set; }
    //    public string value { get; set; }
    //}

    //public class AuxiliaryField
    //{
    //    public string key { get; set; }
    //    public string label { get; set; }
    //    public string value { get; set; }
    //}

    //public class BackField
    //{
    //    public string key { get; set; }
    //    public string label { get; set; }
    //    public string value { get; set; }
    //}

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
        public List<Field> headerFields { get; set; }
        public List<Field> primaryFields { get; set; }
        public List<Field> secondaryFields { get; set; }
        public List<Field> auxiliaryFields { get; set; }
        public List<Field> backFields { get; set; }
        public string transitType { get; set; }
    } 

    public class PkpassData
    {
        public int formatVersion { get; set; }
        public string passTypeIdentifier { get; set; }
        public string serialNumber { get; set; }
        public string teamIdentifier { get; set; }
        public string webServiceURL { get; set; }
        public string authenticationToken { get; set; }
        public string organizationName { get; set; }
        public string description { get; set; }
        public string labelColor { get; set; }
        public string foregroundColor { get; set; }
        public string backgroundColor { get; set; }
        public Barcode barcode { get; set; }
        public BoardingPass boardingPass { get; set; }
        public List<Location> locations { get; set; }
        public string relevantDate { get; set; }
    }
}
