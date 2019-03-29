using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CardsController : Controller
    {
        public CardsController()
        {
        }

        // GET: Cards
        public ActionResult Index()
        {
            return View(WebApplication1.Shared.DB.cards);
        }

        // GET: Cards/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = WebApplication1.Shared.DB.cards.FirstOrDefault(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Number")] Card card)
        {
            if (ModelState.IsValid)
            {
                card.Id = Guid.NewGuid();
                WebApplication1.Shared.DB.cards.Add(card);
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = WebApplication1.Shared.DB.cards.Find(c=> c.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, [Bind("Id,Number")] Card card)
        {
            Console.WriteLine(card.Number);
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int i = WebApplication1.Shared.DB.cards.FindIndex(c => c.Id == id);
                    Card car = new Card(card.Number);
                    car.Id = id;
                    WebApplication1.Shared.DB.cards[i] = car;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = WebApplication1.Shared.DB.cards.Find(c => c.Id == id);

            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var card = WebApplication1.Shared.DB.cards.Find(c => c.Id == id);
            WebApplication1.Shared.DB.cards.Remove(card);
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(Guid id)
        {
            return WebApplication1.Shared.DB.cards.Any(e => e.Id == id);
        }
    }
}
