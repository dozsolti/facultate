using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SwappBackend.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SwappBackend.Models
{
    public class Offer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("isbn")]
        public string ISBN { get; set; }

        [BsonElement("from")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FromUser{ get; set; }

        [BsonElement("to")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ToUser { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("created")]
        public DateTime Created { get; set; }

        [BsonElement("rejects")]
        public List<Reject> Rejects { get; set; }

        public Offer(string iSBN, string fromUser)
        {
            ISBN = iSBN;
            FromUser = fromUser;
            Status = "ready";
            Description = null;
            Created = DateTime.Now;
            Rejects = new List<Reject>();
        }
    }
}
