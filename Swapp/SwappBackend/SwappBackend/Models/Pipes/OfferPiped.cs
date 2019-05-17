using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwappBackend.Models.Pipes
{
    public class OfferPiped
    {
        public string Id { get; set; }

        public string ISBN { get; set; }

        public User FromUser { get; set; }
        public User ToUser { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public List<RejectPiped> Rejects { get; set; }

        public OfferPiped(Offer offer, User fromUser, User toUser, List<RejectPiped> rejects)
        {
            this.Id = offer.Id;
            this.ISBN = offer.ISBN;
            this.Status = offer.Status;
            this.Description = offer.Description;
            this.Created = offer.Created;

            this.FromUser = fromUser;
            this.ToUser = toUser;
            this.Rejects = rejects;
        }

    }
}
