using Demo_EFCore_SQLite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Demo_EFCore_SQLite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PublisherDbContext publisherDbContext;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            publisherDbContext = new PublisherDbContext();

            publisherDbContext.Database.EnsureCreated();

            var authors = new List<Author>
                {
                    new Author
                    {
                        Id = 1,
                        Name ="Carson",
                    },
                                        new Author
                    {
                        Id = 2,
                        Name ="Jose",
                        Books = new List<Book>()
                        {
                            new Book { Title = "Introduction to Machine Learning"},
                            new Book { Title = "Advanced Topics on Machine Learning"},
                            new Book { Title = "Introduction to Computing"}
                        }
                    }
                };

            publisherDbContext.Authors.AddRange(authors);
            publisherDbContext.SaveChanges();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListInfo()
        {
            return Json(publisherDbContext.Authors.Include(x => x.Books));
        }

        [HttpPost]
        public IActionResult RegisterInfo([FromBody] Book entity)
        {
            Book book = new Book()
            {
                AuthorId = 1,
                Id = new Random().Next(1, 100),
                Title = "Testing Purposes"
            };
            publisherDbContext.Books.Add(book);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}