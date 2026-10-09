using Microsoft.AspNetCore.Mvc;

namespace SchollLibraryMini.Web.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
