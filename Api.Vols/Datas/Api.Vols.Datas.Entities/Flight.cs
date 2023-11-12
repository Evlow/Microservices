using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Api.Vols.Datas.Entities
{
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public ObjectId Id { get; set; }

        public string IdToString { get; set; }


        public string? FlightNumber { get; set; }

        public string? Origin { get; set; }


        public string? Destination { get; set; }


        public DateTime Date { get; set; }

        public List<Seat> Sieges { get; set; } = new List<Seat>();

        [BsonElement("items")]
        [JsonPropertyName("items")]
        public InformationAeroplane InformationAeroplane { get; set; }
    }
}
