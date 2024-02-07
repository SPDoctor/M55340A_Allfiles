using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers
{
    public class HomeController : Controller
    {

        private LibraryContext _context;
        private IWebHostEnvironment _environment;

        public HomeController(LibraryContext libraryContext, IWebHostEnvironment environment)
        {
            _context = libraryContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var booksQuery = from b in _context.Books
                             where b.Recommended == true
                             orderby b.Author
                             select b;

            return View(booksQuery);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetBooksByGenre()
        {
            var booksGenreQuery = from b in _context.Books
                                  orderby b.Genre.Name
                                  select b;

            return View(booksGenreQuery);
        }

        public IActionResult LendingBook(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("LendingBook")]
        public async Task<IActionResult> LendingBookPost(int id)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(b => b.Id == id);
            bookToUpdate.Available = false;
            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "",
                b => b.Available))
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(LendingConfirm));
            }
            return View(bookToUpdate);
        }

        public IActionResult LendingConfirm()
        {
            return View();
        }

        public IActionResult GetImage(int id)
        {
            Book requestedBook = _context.Books.FirstOrDefault(b => b.Id == id);
            if (requestedBook != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedBook.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedBook.ImageMimeType);
                }
                else
                {
                    if (requestedBook.PhotoFile.Length > 0)
                    {
                        return File(requestedBook.PhotoFile, requestedBook.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}