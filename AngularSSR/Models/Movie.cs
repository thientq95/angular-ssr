using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSSR.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}
