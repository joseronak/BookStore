using BookStoreTry.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreTry.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookStoreContext _Context;

        public BooksController(BookStoreContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var books = _Context.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Books book)
        {
            if (ModelState.IsValid)
            {
                _Context.Books.Add(book);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
