using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class VacationsController : Controller
    {
        private readonly CardsDataContext _context;

        public VacationsController(CardsDataContext context)
        {
            _context = context;
        }

        // GET: Vacations
        public async Task<IActionResult> Index()
        {
            var cardsDataContext = _context.Vacations.Include(v => v.Card);
            return View(await cardsDataContext.ToListAsync());
        }


        public async Task<IActionResult> Panel(int cardId)
        {
            var cardsDataContext = _context.Vacations.Include(v => v.Card).Where(x=>x.CardId==cardId);
            return View(await cardsDataContext.ToListAsync());
        }

        // GET: Vacations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Card)
                .FirstOrDefaultAsync(m => m.VacationId == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // GET: Vacations/Create
        public IActionResult Create(int cardId)
        {
            ViewData["CardId"] = cardId;
            return View();
        }

        // POST: Vacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacationId,From,To,CardId")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Cards", new { id = vacation.CardId });
            }
            ViewData["CardId"] = vacation.CardId;
            return View(vacation);
        }

        // GET: Vacations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }
            ViewData["CardId"] = new SelectList(_context.Cards, "CardId", "CardId", vacation.CardId);
            return View(vacation);
        }

        // POST: Vacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacationId,From,To,CardId")] Vacation vacation)
        {
            if (id != vacation.VacationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationExists(vacation.VacationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Cards", new { id = vacation.CardId });
            }
            ViewData["CardId"] = new SelectList(_context.Cards, "CardId", "CardId", vacation.CardId);
            return View(vacation);
        }

        // GET: Vacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Card)
                .FirstOrDefaultAsync(m => m.VacationId == id);

            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // POST: Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);
            int cardId = vacation.CardId;
            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Cards", new { id = vacation.CardId });
        }

        private bool VacationExists(int id)
        {
            return _context.Vacations.Any(e => e.VacationId == id);
        }
    }
}
