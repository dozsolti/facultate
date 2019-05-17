using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwappBackend.Models;
using SwappBackend.Models.Pipes;
using SwappBackend.Services;

namespace SwappBackend.Controllers
{
    [Route("api/private/[controller]")]
    [ApiController]
    public partial class OffersController : ControllerBase
    {
        private readonly OfferService _offerService;
        private readonly UserService _userService;

        public OffersController(OfferService offerService, UserService userService)
        {
            _offerService = offerService;
            _userService = userService;
        }

        // GET: api/private/Offers
        [HttpGet]
        public ResponseItem Get()
        {
            User user = HttpContext.Items["user"] as User;
            List<Offer> offers = _offerService.Get(user.Id);
            
            List<OfferPiped> pipedOffers = GetPipedOffers(offers);

            return new ResponseItem("success", pipedOffers);
        }

        // GET: api/private/Offers/5cd70e2e0507e317f8a50b9c
        [HttpGet("{offerId}")]
        public ResponseItem Get(string offerId)
        {
            User user = HttpContext.Items["user"] as User;

            if (_offerService.Exist(offerId) == false)
                return new ResponseItem("error", "Oferta nu exista.");

            Offer offer = _offerService.GetIfAccess(offerId, user.Id);
            if (offer == null)
                return new ResponseItem("error", "Nu ai acces la aceasta oferta.");

            offer.Status = CalculateStatus(offer, user);
            return new ResponseItem("success", GetPipedOffer(offer));
        }
        private string CalculateStatus(Offer offer, User user)
        {
            /* Aceasta functie trebuie sa returneze:
             * - ready = asteapta sa fie acceptat
             * - waiting:
             * -- pending = daca user e toUser si inca nu a acceptat acceptul meu
             * -- asking = daca user e fromUser si inca nu a acceptat acceptul
             * - rejected = daca fromUser a dat "refuza" la acceptul toUserului
             * - running = daca user e fromUser sau toUser si amandoi au dat accept
             * - closed = daca unul a inchis.
             * Nota: closed trebuie despartit in 2, sa se stie cine a dat closed
             */
            bool wasRejected = offer.Rejects!=null && offer.Rejects.FirstOrDefault(reject=>reject.UserId == user.Id)!=null;
            if (wasRejected)
                return "rejected";
            
             if(offer.Status == "waiting")
            {
                if (user.Id == offer.ToUser)
                    return "pending";

                if (user.Id == offer.FromUser)
                        return "asking";
                    
            }
            return offer.Status;
        }
        // POST: api/private/Offers
        [HttpPost()]
        public ResponseItem Post(Offer _offer)
        {
            User user = HttpContext.Items["user"] as User;
            _offer.FromUser = user.Id;

            string createStatus = _offerService.Create(_offer);

            if (createStatus.StartsWith("id: ")==false)
                return new ResponseItem("error", createStatus);
            else
                return new ResponseItem("success", createStatus.Substring("id: ".Length));

        }

        // PUT: api/private/Offers/5
        [HttpPut("{offerId}")]
        public ResponseItem Put(string offerId, [FromForm] string action, [FromForm] string message)
        {
            //Schimbarile care se pot face sunt:
            //- sa accepte oferta initiala
            //- creatorul sa dea acordul SAU refuzul la acceptarea anterioara
            //- o parte inchide

            User user = HttpContext.Items["user"] as User;

            if (_offerService.Exist(offerId) == false)
                return new ResponseItem("error", "Oferta nu exista.");

            Offer offer = _offerService.GetIfAccess(offerId, user.Id);
            if (offer == null)
                return new ResponseItem("error", "Nu ai acces la aceasta oferta.");

            User userFrom = _userService.Get(offer.FromUser);

            if (action == "accept")
            {
                if(offer.Status != "ready")
                    return new ResponseItem("error", "Ceva nu mers bine. (Oferta este deja in rulare)");

                if(offer.FromUser == user.Id)
                    return new ResponseItem("error", "Ceva nu mers bine. (Nu poti accepta propriile oferte)");

                string updateError = _offerService.Accept(offer.Id, user.Id);
                return Program.GetResponseItemFromError(updateError, "Oferta a fost acceptata.");

            }

            if (action == "aprove")
            {
                if (offer.Status != "waiting")
                    return new ResponseItem("error", "Ceva nu mers bine. (Oferta nu se poate aproba)");

                string updateError = _offerService.Aprove(offer.Id);
                return Program.GetResponseItemFromError(updateError, "Oferta a fost inceputa.");

            }
            if (action == "reject")
            {
                if (offer.Status != "waiting")
                    return new ResponseItem("error", "Ceva nu mers bine. (Oferta nu se poate refuza)");

                string updateError = _offerService.Reject(offer.Id, message);
                return Program.GetResponseItemFromError(updateError, "Oferta a fost refuzata.");

            }
            if (action == "close")
            {
                if (offer.Status != "running")
                    return new ResponseItem("error", "Ceva nu mers bine. (Oferta nu este in rulare, deci nu o poti inchide.)");
                if( offer.FromUser!= user.Id)
                    return new ResponseItem("error", "Ceva nu mers bine. (Tu nu poti inchide aceasta oferta.)");

                string updateError = _offerService.Close(offer.Id);
                return Program.GetResponseItemFromError(updateError, "Oferta a fost inchisa.");

            }
            return new ResponseItem("success", "Success.");
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //poate sa o stearga doar daca status == "ready"
        }

        List<OfferPiped> GetPipedOffers(List<Offer> offers)
        {
            List<OfferPiped> pipedOffers = new List<OfferPiped>();
            foreach (Offer offer in offers)
                pipedOffers.Add(GetPipedOffer(offer));
            return pipedOffers;
        }
        OfferPiped GetPipedOffer(Offer offer)
        {
            List<RejectPiped> rejects = new List<RejectPiped>();
            if(offer.Rejects != null)
                foreach (Reject reject in offer.Rejects)
                    rejects.Add(new RejectPiped(_userService.Get(reject.UserId), reject.Message));
            
            return new OfferPiped(offer, _userService.Get(offer.FromUser), _userService.Get(offer.ToUser), rejects);
        }

        
    }
}
