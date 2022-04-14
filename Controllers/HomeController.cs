using Lesson_Entity_FrameWork.Models;
using Lesson_Entity_FrameWork.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson_Entity_FrameWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IBookService _bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("[controller]/")]
        public IEnumerable<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpDelete("[controller]/")]
        public void DeleteBook( int id)
        {
            _bookService.Delete(id);
        }

        [HttpPost("[controller]/")]
        public void AddBook(string thisBook, string author)
        {
            _bookService.Add(thisBook, author);
        }
    }
}