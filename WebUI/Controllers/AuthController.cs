using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
    //класс-контроллер для аутентификации
    public class AuthController : Controller
    {
        private readonly CardsDataContext _context;

        //конструктор класса для того, чтобы передать ссылку на конткст данных
        public AuthController(CardsDataContext context)
        {
            _context = context;
        }

        //для отображения формы аутентификации
        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }
        //метод для выхода
        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("Auth");
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Index", "Auth");
        }


        //проверка введенных пользователем данных
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("UserName,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Cards.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
               //если пользователь найденЮ
                if (user != null)
                {
                  
                    HttpContext.Session.SetString("Auth", login.UserName);
                    HttpContext.Session.SetString("IsAdmin", user.IsAdmin ? "1" : "0");
                    return RedirectToAction("Index", "Cards");
                }

            }
            TempData["AuthError"] = "Неверные данные учетной записи";
            return View(login);
        }

    }
}
