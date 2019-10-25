using GyandhaaraLibrary.DataModel;
using GyandhaaraLibrary.Service;
using GyandhaaraLibrary.Service.Interfaces;
using GyandhaaraLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GyandhaaraLibrary.View.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        ILanguageService languageService;
        IGenreService genreService;

        public BookController()
        {
            bookService = new BookService();
            languageService = new LanguageService();
            genreService = new GenreService();
        }

        public ActionResult Index()
        {
            var sourceList = bookService.GetAll();

            List<BookListViewModel> targetList = new List<BookListViewModel>();
            foreach (var source in sourceList)
            {
                var languageName = languageService.FindBy(x => x.LanguageID == source.LanguageID).Name;
                var genreName = genreService.FindBy(x => x.GenreID == source.GenreID).Name;
                BookListViewModel target = new BookListViewModel
                {
                    BookID = source.BookID,
                    Edition = source.Edition,
                    Title = source.Title,
                    Author = source.Author,
                    PublishDate = source.PublishDate.ToShortDateString(),
                    Publisher = source.Publisher,
                    Genre = genreName,
                    Language = languageName

                };
                targetList.Add(target);
            }

            return View(targetList);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            CreateBookVM viewmodel = new CreateBookVM();
            viewmodel.Genres.Add(new GenreDropDownVM { GenreID = 1, Name = ".NET" });
            viewmodel.Languages.Add(new LanguageDropDownVM { LanguageID = 1, Name = "English" });
            viewmodel.Suppliers.Add(new SupplierDropDownVM { SupplierID = 1, Name = "Gyandhaara Book Store" });
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(CreateBookVM source, int? GenreID, int? LanguageID, int? SupplierID, HttpPostedFileBase file)
        {
            try
            {
                Book target = new Book
                {
                    Code = source.Code,
                    Title = source.Title,
                    Isbn = source.Isbn,
                    Edition = source.Edition,
                    EntryDate = source.EntryDate.Value,
                    Publisher = source.Publisher,
                    PublishDate = source.PublishDate.Value,
                    TotalPages = source.TotalPages.Value,
                    Author = source.Author,
                    Price = source.Price.Value,
                };
                if (file.ContentLength > 0)
                {
                    target.Photo.Image = new byte[file.ContentLength];
                    file.InputStream.Read(target.Photo.Image, 0, file.ContentLength);
                    target.Photo.FileName = file.FileName;
                }
                bookService.Add(target);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var source = bookService.FindBy(x => x.BookID == id);
            CreateBookVM target = new CreateBookVM
            {
                Code = source.Code,
                Title = source.Title,
                Isbn = source.Isbn,
                Edition = source.Edition,
                EntryDate = source.EntryDate,
                Publisher = source.Publisher,
                PublishDate = source.PublishDate,
                TotalPages = source.TotalPages,
                Author = source.Author,
                Price = source.Price,
                GenreID = source.GenreID,
                SupplierID = source.SupplierID,
                PhotoID = source.PhotoID,
                LanguageID = source.LanguageID
            };

            target.Photo.Image = source.Photo.Image;
            return View(target);
        }

        [HttpPost]
        public ActionResult Edit(int id, CreateBookVM source, int? GenreID, int? LanguageID, int? SupplierID, HttpPostedFileBase file)
        {
            try
            {
                Book target = new Book
                {
                    Code = source.Code,
                    Title = source.Title,
                    Isbn = source.Isbn,
                    Edition = source.Edition,
                    EntryDate = source.EntryDate.Value,
                    Publisher = source.Publisher,
                    PublishDate = source.PublishDate.Value,
                    TotalPages = source.TotalPages.Value,
                    Author = source.Author,
                    Price = source.Price.Value,
                };
                if (file.ContentLength > 0)
                {
                    target.Photo.Image = new byte[file.ContentLength];
                    file.InputStream.Read(target.Photo.Image, 0, file.ContentLength);
                    target.Photo.FileName = file.FileName;
                }
                bookService.Edit(target);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
