using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SwappBackend.Services;
using System.Security.Cryptography;

namespace SwappBackend.Models
{
    // construit pe baza:
    // https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-2.2&tabs=visual-studio#add-a-model

    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("telephone")]
        public string Telephone { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("hashedPassword")]
        public string HashedPassword { get; set; }

        public User(string name, string email, string telephone, string username, string password)
        {
            Name = name;
            Email = email;
            Telephone = telephone;
            Username = username;
            HashedPassword = CryptoService.Hash(password);
        }
    }
}
