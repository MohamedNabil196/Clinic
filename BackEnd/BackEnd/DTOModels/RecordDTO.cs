using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.Build.Framework;

namespace BackEnd.DTOModels
{
    public class RecordDTO
    {
        public string name { get; set; }
        public string diagnosis { get; set; }
        public string treatmentPlan { get; set; }
        public DateTime date { get; set; }

    }
}
