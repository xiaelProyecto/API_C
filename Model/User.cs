using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Model
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("nickname")]
        public string nickname { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("mail")]
        public string mail { get; set; }
        [BsonElement("age")]
        public Int32 age { get; set; }
        [BsonElement("avatar")]
        public string avatar { get; set; }
        [BsonElement("rol")]
        public string rol { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
        [BsonElement("favm")]
        public IEnumerable<string> favm { get; set; }
        [BsonElement("favn")]
        public IEnumerable<string> favn { get; set; }
    }
}
