using Microsoft.AspNetCore.Mvc;
using SchoolLibraryMini.Services.Contracts;

namespace SchollLibraryMini.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAll();

            return View(books);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title, string author)
        {
            await _bookService.Create(title, author);

            return RedirectToAction(nameof(Index));
        }
    }
}
