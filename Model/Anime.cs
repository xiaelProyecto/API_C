using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.Model
{
    [BsonIgnoreExtraElements]
    public class Anime
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("titulo")]
        public string titulo { get; set; }
        [BsonElement("imageurl")]
        public string imageurl { get; set; }
        [BsonElement("trailerurl")]
        public string trailerurl { get; set; }
        [BsonElement("lanzamiento")]
        public DateTime lanzamiento { get; set; }
        [BsonElement("categoria")]
        public IEnumerable<string> categoria { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
        [BsonElement("director")]
        public string director { get; set; }

    }
}
