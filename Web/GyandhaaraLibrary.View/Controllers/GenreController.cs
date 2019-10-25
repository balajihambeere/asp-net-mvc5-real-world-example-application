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
    public class GenreController : Controller
    {
        IGenreService genreService;
        public GenreController()
        {
            genreService = new GenreService();
        }


        public ActionResult Index()
        {
            List<GenreVM> targetList = new List<GenreVM>();
            IEnumerable<Genre> sourceList = genreService.GetAll().ToList();
            foreach (var source in sourceList)
            {
                GenreVM target = new GenreVM
                {
                    GenreID = source.GenreID,
                    Name = source.Name,
                    Description = source.Description
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
            return View(new GenreVM());
        }


        [HttpPost]
        public ActionResult Create(GenreVM viewModel)
        {
            try
            {
                genreService.Add(new Genre { Name = viewModel.Name, Description = viewModel.Description });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = genreService.FindBy(x => x.GenreID == id);
            GenreVM viewModel = new GenreVM
            {
                GenreID = entity.GenreID,
                Name = entity.Name,
                Description = entity.Description
            };
            return View(viewModel);
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GenreVM source)
        {
            try
            {
                Genre target = new Genre
                {
                    GenreID = source.GenreID,
                    Name = source.Name,
                    Description = source.Description
                };
                genreService.Edit(target);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Genre/Delete/5
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
