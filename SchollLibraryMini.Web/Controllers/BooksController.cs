using Microsoft.AspNetCore.Mvc;
using SchoolLibraryMini.Data;
using SchoolLibraryMini.Data.Entities;

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

        [HttpPost]
        public IActionResult Create(string title, string author)
        {
            var _author = _db.Authors.FirstOrDefault(a => a.Name == author);

            if (_author is null)
            {
                _author = new Author
                {
                    AuthorId = Guid.NewGuid(),
                    Name = author
                };
                _db.Authors.Add(_author);
            }

            var book = new Book
            {
                BookId = Guid.NewGuid(),
                Title = title,
                ISBN = Guid.NewGuid().ToString()[..13],
                PublicationYear = 2026,
                TotalCopies = 10,
                AuthorId = _author.AuthorId,
                Author = _author
            };

            _db.Books.Add(book);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
