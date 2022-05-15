using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace API_C.Model
{
    [BsonIgnoreExtraElements]
    public class Mytoken
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("token")]
        public string token { get; set; }
    }
}
