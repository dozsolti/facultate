using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SwappBackend.Models;
using System;
using System.Linq;

namespace SwappBackend.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DBlink"));
            var database = client.GetDatabase("swapp");
            _users = database.GetCollection<User>("Users");
        }

        public User Get(string userId)
        {
            try
            {
                return _users.Find<User>(u => u.Id == userId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public User GetByUsername(string username)
        {
            try
            {
                return _users.Find<User>(u => u.Username == username).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public User Login(string username, string password)
        {
            try
            {
                return _users.Find<User>(u => u.HashedPassword == CryptoService.Hash(password) && u.Username == username).FirstOrDefault();
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public string Create(User user)
        {
            try
            {
                bool exists = _users
                    .Find<User>(u =>
                        user.Username == u.Username ||
                        user.Email == u.Email ||
                        user.Telephone == u.Telephone
                    )
                    .FirstOrDefault() != null;

                if (exists)
                    throw new Exception("Utilizator exista deja.");

                _users.InsertOne(user);
                return String.Empty;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
     
    }
}
