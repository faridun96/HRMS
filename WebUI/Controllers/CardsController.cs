using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WebUI.Models;
using Microsoft.AspNetCore.Http;

namespace WebUI.Controllers
{
    public class CardsController : Controller
    {
        private readonly CardsDataContext _context;

        public CardsController(CardsDataContext context)
        {
            _context = context;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Auth") == null)
            {
                return RedirectToAction("Index", "Auth");

            }
            else if (HttpContext.Session.GetString("IsAdmin") == "0")
            {
                var card = await _context.Cards
                  .FirstOrDefaultAsync(m => m.UserName == HttpContext.Session.GetString("Auth"));
                if (card == null)
                {
                    return NotFound();
                }
                return RedirectToAction("Details", new { id = card.CardId });

            }
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") == "0")
            {
                return RedirectToAction("Index", "Auth");

            }

            return View();
        }



        public async Task<IActionResult> Search(string phrase)
        {

            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") == "0")
            {
                return RedirectToAction("Index", "Auth");
            }

            var cards = _context.Cards.Where(x => x.Nomer == phrase);
            if (cards.Count() > 0)
            {
                return RedirectToAction("Details", "Cards", new { id = cards.FirstOrDefault().CardId });

            }
            else
            {
                cards = _context.Cards.Where(x => x.LastName.Contains(phrase));
                if (cards.Count() > 0)
                {
                    return View("Index", cards);
                }
                else
                    return View("NotFound");
            }
        }


        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardId,Nomer,IsMilitary,LastName,FirstName,MiddleName,BirthDay,BirthPlace,Nationality,Party,IsInUnion,Education,AfterSchool,School,EducationType,Degree,Profession,Diploma,GeneralProfession,AllWorkDuration,ContiniousAllWorkDuration,LastJob,FamilyStatus,PassportNumber,PassportSerie,PassportIssuer,PassportDate,Address,Phone,Posted,MilitaryGroup,MilitaryCategory,MilitaryInstitution,MilitaryPosition,MilitaryProfession,MilitaryHealth,MilitaryUnit,MilitarySpecialNumber,AdditionalInfo,ResignationReason,UserName,IsAdmin,Password")] Card card)
        {

            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") == "0")
            {
                return RedirectToAction("Index", "Auth");

            }
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") == "0")
            {
                return RedirectToAction("Index", "Auth");

            }
            if (HttpContext.Session.GetString("Auth") == null)
            {
                return RedirectToAction("Index", "Auth");

            }
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardId,Nomer,IsMilitary,LastName,FirstName,MiddleName,BirthDay,BirthPlace,Nationality,Party,IsInUnion,Education,AfterSchool,School,EducationType,Degree,Profession,Diploma,GeneralProfession,AllWorkDuration,ContiniousAllWorkDuration,LastJob,FamilyStatus,PassportNumber,PassportSerie,PassportIssuer,PassportDate,Address,Phone,Posted,MilitaryGroup,MilitaryCategory,MilitaryInstitution,MilitaryPosition,MilitaryProfession,MilitaryHealth,MilitaryUnit,MilitarySpecialNumber,AdditionalInfo,ResignationReason,UserName,IsAdmin,Password")] Card card)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") == "0")
            {
                return RedirectToAction("Index", "Auth");

            }
            if (id != card.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.CardId))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") == "0")
            {
                return RedirectToAction("Index", "Auth");

            }
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Auth") == null || HttpContext.Session.GetString("IsAdmin") == "0")
            {
                return RedirectToAction("Index", "Auth");

            }
            var card = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.CardId == id);
        }
    }
}
