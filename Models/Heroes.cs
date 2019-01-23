using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeroesWebApi
{
    public class Heroes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }

        [BsonElement("id")]
        public string heroNumber { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
