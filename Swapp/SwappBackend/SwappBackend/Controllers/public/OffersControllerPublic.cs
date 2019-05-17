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
    
    [Route("api/public/[controller]")]
    public partial class OffersController : ControllerBase
    {

        // GET: api/public/Offers/latest
        [HttpGet("latest")]
        public ResponseItem GetLatest()
        {
            List<Offer> offers = _offerService.GetLatest();

            List<OfferPiped> pipedOffers = GetPipedOffers(offers);

            return new ResponseItem("success", pipedOffers);
        }

        // GET: api/public/Offers/book/5cd70e2e0507e317f8a50b9c
        [HttpGet("book/{isbn}")]
        public ResponseItem GetByIsbn(string isbn)
        {
            List<Offer> offers = _offerService.GetByIsbn(isbn);

            List<OfferPiped> pipedOffers = GetPipedOffers(offers);

            return new ResponseItem("success", pipedOffers);
        }

    }
}
