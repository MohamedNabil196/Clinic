using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    [BsonIgnoreExtraElements]
    public class Record
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("diagnosis")]
        public string Diagnosis { get; set; }
        [BsonElement("treatmentPlan")]
        public string TreatmentPlan { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }

    }
}