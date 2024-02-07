using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApp.Controllers
{
    public class BookController : Controller
    {
        List<Models.Book> books = new List<Models.Book>();

        public BookController()
        {
            books.Add(new Models.Book() { Id = 1, Author = "Grahame Greene", Title = "The Honorary Consul", Published = 1973 });
            books.Add(new Models.Book() { Id = 2, Author = "Joseph Heller", Title = "Catch-22", Published = 1961 });
            books.Add(new Models.Book() { Id = 3, Author = "H G Wells", Title = "The War of the Worlds", Published = 1898 });
            books.Add(new Models.Book() { Id = 4, Author = "James Joyce", Title = "Ulysses", Published = 1922 });
        }

        // GET: BookController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = books.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
