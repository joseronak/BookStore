using BookStoreTry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreTry.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly BookStoreContext _Context;

        public TransactionsController(BookStoreContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            var transactions = _Context.Transactions
                .Include(t => t.User)
                .Include(t => t.Book)
                .ToList();
            return View(transactions);
        }

        public IActionResult Create()
        {
            ViewBag.Users = _Context.Users.ToList();
            ViewBag.Books = _Context.Books.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transactions transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.TransactionDate = DateTime.Now;
                _Context.Transactions.Add(transaction);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
    }
}
