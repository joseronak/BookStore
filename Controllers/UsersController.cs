using BookStoreTry.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreTry.Controllers
{
    public class UsersController : Controller
    {
        private readonly BookStoreContext _Context;

        public UsersController(BookStoreContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var users = _Context.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _Context.Users.Add(user);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
