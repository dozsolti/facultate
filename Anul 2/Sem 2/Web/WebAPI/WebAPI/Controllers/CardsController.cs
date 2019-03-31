using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        // GET: api/Cards/5
        [HttpGet("{token}")]
        public string Get(string token)
        {
            object logginedUser = AuthService.DecodeToken(token);
            if (logginedUser.GetType().ToString() == "System.String")
                return "{\"status\":\"error\",\"message\":\"" + logginedUser + "\"}";

            User user = logginedUser as User;

            StringBuilder myCards = new StringBuilder();

            if (user.Cards.Count > 0)
            {
                foreach (Card card in user.Cards)
                    myCards.Append("{ \"id\":\"" + card.Id.ToString() + "\",\"number\":\"" + card.Number.ToString() + "\" },");
                //Sterg virgula de la sfarsit
                myCards.Remove(myCards.Length - 1, 1);
            }
            else
                myCards.Append("");

            return "{\"status\":\"success\",\"cards\":[" + myCards.ToString() + "]}";
            
        }

        // POST: api/Cards
        [HttpPost("{token}")]
        public string Post(string token,[FromForm] string value)
        {
            object logginedUser = AuthService.DecodeToken(token);
            if (logginedUser==null && logginedUser.GetType().ToString() == "System.String")
                return "{\"status\":\"error\",\"message\":\"" + logginedUser + "\"}";

            User user = logginedUser as User;
            user.Cards.Add(new Card(value));

            return "{\"status\":\"success\",\"message\":\"Cardul a fost salvat\"}";

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}/{token}")]
        public string Delete(string id,string token)
        {
            object logginedUser = AuthService.DecodeToken(token);
            if (logginedUser.GetType().ToString() == "System.String")
                return "{\"status\":\"error\",\"message\":\"" + logginedUser + "\"}";

            User user = logginedUser as User;
            user.Cards.RemoveAt(
                user.Cards.FindIndex(c=>c.Id.ToString() == id)
                );

            return "{\"status\":\"success\",\"message\":\"Cardul a fost sters\"}";

        }
    }
}
