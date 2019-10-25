using GyandhaaraLibrary.DataModel;
using GyandhaaraLibrary.Service;
using GyandhaaraLibrary.Service.Interfaces;
using GyandhaaraLibrary.ViewModel.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GyandhaaraLibrary.View.Controllers
{
    public class HomeController : Controller
    {
        IPhotoService photoService;
        IBookService bookService;
        ILanguageService languageService;
        IGenreService genreService;
        public HomeController()
        {
            bookService = new BookService();
            photoService = new PhotoService();
            languageService = new LanguageService();
            genreService = new GenreService();
        }

        public ActionResult Index()
        {
            IList<PhotoViewModel> targetList = new List<PhotoViewModel>();
            IEnumerable<Photo> sourceList = photoService.GetAll();
            foreach (var source in sourceList)
            {
                PhotoViewModel target = new PhotoViewModel
                {
                    PhotoID = source.PhotoID,
                    FileName = source.FileName,
                    Image = source.Image
                };
                targetList.Add(target);
            }
            return View(targetList);
        }



        public ActionResult Details(int id)
        {
            var bookSource = bookService.FindBy(x => x.PhotoID == id);
            var photoSource = photoService.FindBy(x => x.PhotoID == id);
            var languageName = languageService.FindBy(x => x.LanguageID == bookSource.LanguageID).Name;
            var genreName = genreService.FindBy(x => x.GenreID == bookSource.GenreID).Name;

            ViewBookViewModel target = new ViewBookViewModel
            {
                Title = bookSource.Title,
                Edition = bookSource.Edition,
                Publisher = bookSource.Publisher,
                PublishDate = bookSource.PublishDate.ToShortDateString(),
                TotalPages = bookSource.TotalPages,
                Author = bookSource.Author,
                //Map Photo details
                PhotoID = photoSource.PhotoID,
                Image = photoSource.Image,
                Language = languageName,
                Genre = genreName
            };
            return View(target);
        }

        public FileContentResult GetImage(int id)
        {
            var photo = photoService.FindBy(x => x.PhotoID == id);
            return File(photo.Image, photo.FileName);

        }
    }
}