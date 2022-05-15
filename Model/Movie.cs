using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace API_C.Model
{
    [BsonIgnoreExtraElements]
    public class Movie 
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
        [BsonElement("plataformas")]
        public IEnumerable<Object> plataformas { get; set; }
        [BsonElement("reparto")]
        public IEnumerable<Object> reparto { get; set; }
        [BsonElement("edadminima")]
        public Int32 edadminima { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
    }
}
