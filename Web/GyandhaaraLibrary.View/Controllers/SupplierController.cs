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
    public class SupplierController : Controller
    {
        ISupplierService supplierService;

        public SupplierController()
        {
            supplierService = new SupplierService();
        }

        public ActionResult Index()
        {
            IList<IndexSupplierVM> targetList = new List<IndexSupplierVM>();
            IEnumerable<Supplier> sourceList = supplierService.GetAll().ToList();
            foreach (var source in sourceList)
            {
                IndexSupplierVM target = new IndexSupplierVM
                {
                    SupplierID = source.SupplierID,
                    Name = source.Name,
                    Contact = source.Contact,
                    Email = source.Email
                };
                targetList.Add(target);
            }
            return View(targetList);
        }

        public ActionResult Details(int id)
        {
            var source = supplierService.GetSupplierByID(id);
            AddSupplierViewModel target = new AddSupplierViewModel
            {
                SupplierID = source.SupplierID,
                Name = source.Name,
                Contact = source.Contact,
                Email = source.Email,
                AddressID = source.AddressID.Value,
                Street = source.Address.Street,
                City = source.Address.City,
                State = source.Address.State,
                Country = source.Address.Country,
                ZipCode = source.Address.ZipCode
            };
            return View(target);
        }

        public ActionResult Create()
        {
            return View(new AddSupplierViewModel());
        }

        [HttpPost]
        public ActionResult Create(AddSupplierViewModel source)
        {
            try
            {
                Supplier target = new Supplier
                {
                    Name = source.Name,
                    Contact = source.Contact,
                    Email = source.Email,
                    Address = new Address
                    {
                        Street = source.Street,
                        City = source.City,
                        State = source.State,
                        Country = source.Country,
                        ZipCode = source.ZipCode
                    }
                };
                supplierService.Add(target);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var source = supplierService.GetSupplierByID(id);
            AddSupplierViewModel target = new AddSupplierViewModel
            {
                SupplierID = source.SupplierID,
                Name = source.Name,
                Contact = source.Contact,
                Email = source.Email,
                AddressID = source.AddressID.Value,
                Street = source.Address.Street,
                City = source.Address.City,
                State = source.Address.State,
                Country = source.Address.Country,
                ZipCode = source.Address.ZipCode
            };
            return View(target);
        }

        [HttpPost]
        public ActionResult Edit(int id, AddSupplierViewModel source)
        {
            try
            {
                Supplier target = new Supplier
                {
                    SupplierID = source.SupplierID,
                    Name = source.Name,
                    Contact = source.Contact,
                    Email = source.Email,
                    Address = new Address
                    {
                        AddressID = source.AddressID,
                        Street = source.Street,
                        City = source.City,
                        State = source.State,
                        Country = source.Country,
                        ZipCode = source.ZipCode
                    }
                };
                supplierService.Edit(target);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
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
