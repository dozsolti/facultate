using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SwappBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwappBackend.Services
{
    public class OfferService
    {
        private readonly IMongoCollection<Offer> _offers;

        public OfferService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DBlink"));
            var database = client.GetDatabase("swapp");
            _offers = database.GetCollection<Offer>("Offers");
        }
        #region Create
        public string Create(Offer offer)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(offer.ISBN))
                    throw new Exception("Trebuie sa introduci un isbn valid.");

                _offers.InsertOne(offer);
                
                return "id: "+offer.Id;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Read
        public List<Offer> GetLatest()
        {
            try
            {
                List<Offer> offers = _offers.Find<Offer>(o => o.Status == "ready").ToList();
                return offers.GetRange(0,Math.Min(offers.Count,10));
            }
            catch (Exception ex)
            {
                return new List<Offer>();
            }
        }
        public List<Offer> Get(string userId)
        {
            try
            {
                return _offers.Find<Offer>(o => o.FromUser == userId || o.ToUser == userId).ToList();
            }
            catch(Exception ex)
            {
                return new List<Offer>();
            }
        }

        public bool Exist(string offerId)
        {
            return _offers.Find<Offer>(o => o.Id == offerId).FirstOrDefault()!=null;
        }

        public Offer GetIfAccess(string offerId, string userId)
        {
            //1. sa se potriveasca idu
            //2. daca toUser este gol inseamna ca oferta nu a fost inca acceptata, asa ca o poate vedea oricine
            //3. in caz ca toUser Nu este gol, doar cel care a creat si cel care l-a acceptat poate sa o vada
            return _offers.Find<Offer>(o => o.Id == offerId && 
                ( String.IsNullOrEmpty(o.ToUser) || (o.FromUser == userId || o.ToUser == userId))
            ).FirstOrDefault();
        }

        public List<Offer> GetByIsbn(string isbn)
        {
            try
            {
                return _offers.Find<Offer>(o => o.ISBN == isbn && o.Status == "ready").ToList();
            }
            catch (Exception ex)
            {
                return new List<Offer>();
            }
        }

        #endregion

        #region Update

        public string Accept(string offerId, string toUser)
        {
            try
            {
                Offer newOffer = _offers.Find<Offer>(o=>o.Id==offerId).FirstOrDefault();
                if (newOffer == null)
                    throw new Exception("Oferta nu exista.");

                newOffer.ToUser = toUser;
                newOffer.Status = "waiting";
                _offers.ReplaceOne<Offer>(o => o.Id == offerId, newOffer);

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string Aprove(string offerId)
        {
            try
            {
                Offer offer = _offers.Find<Offer>(o => o.Id == offerId).FirstOrDefault();
                if (offer == null)
                    throw new Exception("Oferta nu exista.");

                offer.Status = "running";
                _offers.ReplaceOne<Offer>(o => o.Id == offerId, offer);

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string Reject(string offerId,string message)
        {
            try
            {
                Offer offer = _offers.Find<Offer>(o => o.Id == offerId).FirstOrDefault();
                if (offer == null)
                    throw new Exception("Oferta nu exista.");

                offer.Rejects.Add(new Reject(offer.ToUser, message));
                offer.Status = "ready";
                offer.ToUser = null;

                _offers.ReplaceOne<Offer>(o => o.Id == offerId, offer);

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Close(string offerId)
        {
            try
            {
                Offer offer = _offers.Find<Offer>(o => o.Id == offerId).FirstOrDefault();
                if (offer == null)
                    throw new Exception("Oferta nu exista.");

                offer.Status = "closed";
                _offers.ReplaceOne<Offer>(o => o.Id == offerId, offer);

                return String.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        
        #endregion

    }
}
