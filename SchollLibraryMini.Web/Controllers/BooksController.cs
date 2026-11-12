using Microsoft.AspNetCore.Mvc;
using SchoolLibraryMini.Data;

namespace SchollLibraryMini.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDbContext _db;

        public BooksController(LibraryDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books
                        .OrderBy(b => b.Title)
                        .ToList();

            return View(books);

        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
