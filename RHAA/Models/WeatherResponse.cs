using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RHAA.Models
{
    [DataContract]
    public class WeatherResponse
    {
        [DataMember(Name = "coord")]
        public Coord coord { get; set; }
        [DataMember(Name ="weather")]
        public Weather[] weather { get; set; }
        [DataMember(Name = "main")]
        public Main main { get; set; }
    }


    [DataContract]
    public class Coord
    {
        [DataMember(Name = "lon")]
        public string Lon { get; set; }
        [DataMember(Name = "lat")]
        public string Lat { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "main")]
        public string Main { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember(Name = "temp")]
        public double Temp { get; set; }
    }


}