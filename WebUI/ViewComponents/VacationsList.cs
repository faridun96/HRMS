using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WebUI.Models;

namespace WebUI
{
    [ViewComponent(Name = "VacationsList")]
    public class VacationsList : ViewComponent
    {
        private readonly CardsDataContext _context;

        public VacationsList(CardsDataContext context)
        {
            _context = context;
        }



        public async Task<IViewComponentResult> InvokeAsync(int cardId)
        {
            var cardsDataContext = _context.Vacations.Include(v => v.Card).Where(x=>x.CardId==cardId);
            ViewData["cardId"] = cardId;
            return View("List", await cardsDataContext.ToListAsync());
        }

    }
}
