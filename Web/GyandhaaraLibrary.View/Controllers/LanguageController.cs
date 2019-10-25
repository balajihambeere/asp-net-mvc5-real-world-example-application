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
    public class LanguageController : Controller
    {
        ILanguageService languageService;
        public LanguageController()
        {
            languageService = new LanguageService();
        }

        public ActionResult Index()
        {
            IList<LanguageVM> targetList = new List<LanguageVM>();
            IEnumerable<Language> sourceList = languageService.GetAll().ToList();
            foreach (var source in sourceList)
            {
                LanguageVM target = new LanguageVM
                {
                    LanguageID = source.LanguageID,
                    Name = source.Name,
                    Description = source.Description
                };
                targetList.Add(target);
            }
            return View(targetList);
        }

        public ActionResult Create()
        {
            return View(new LanguageVM());
        }

        [HttpPost]
        public ActionResult Create(LanguageVM source)
        {
            try
            {
                Language target = new Language
                {
                    LanguageID = source.LanguageID,
                    Name = source.Name,
                    Description = source.Description
                };
                languageService.Add(target);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var source = languageService.FindBy(x => x.LanguageID == id);
            LanguageVM target = new LanguageVM
            {
                LanguageID = source.LanguageID,
                Name = source.Name,
                Description = source.Description
            };
            return View(target);
        }

        [HttpPost]
        public ActionResult Edit(int id, LanguageVM source)
        {
            try
            {
                Language target = new Language
                {
                    LanguageID = source.LanguageID,
                    Name = source.Name,
                    Description = source.Description
                };
                languageService.Edit(target);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
