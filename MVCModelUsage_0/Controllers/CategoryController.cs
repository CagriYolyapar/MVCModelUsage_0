using MVCModelUsage_0.DesignPatterns.SingletonPattern;
using MVCModelUsage_0.Models;
using MVCModelUsage_0.ViewModels.PageViewModels;
using MVCModelUsage_0.ViewModels.PureViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCModelUsage_0.Controllers
{
    public class CategoryController : Controller
    {
        NorthwindEntities _db;

        public CategoryController()
        {
            _db = DBTool.DBInstance;
        }


        #region VMMethods
        private List<ProductVM> GetProductVMs()
        {
            return _db.Products.Select(x => new ProductVM
            {
                ID = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
            }).ToList();
        }

        private List<CategoryVM> GetCategoryVMs()
        {
            return _db.Categories.Select(x => new CategoryVM
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
            }).ToList();
        }

        private List<SupplierVM> GetSupplierVms()
        {
            return _db.Suppliers.Select(x => new SupplierVM
            {
                ID = x.SupplierID,
                CompanyName = x.CompanyName

            }).ToList();
        }

        #endregion

        public ActionResult ListCategories()
        {
            List<CategoryVM> categories = GetCategoryVMs();
            List<ProductVM> products = GetProductVMs();
            List<SupplierVM> suppliers = GetSupplierVms();

            ListCategoriesPageVM cpvm = new ListCategoriesPageVM
            {
                Products = products,
                Categories = categories,
                Suppliers = suppliers
            };
            return View(cpvm);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM category)
        {
            Category c = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            _db.Categories.Add(c);
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = _db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryVM
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).FirstOrDefault();

            AddUpdateCategoryPageVM upcvm = new AddUpdateCategoryPageVM
            {
                Category = cvm
            };
            return View(upcvm);
        }

        //Eger size Front End'den Model bir paket halinde geliyorsa siz bunu spesifik yakalama yöntemini gerçekleştirmek icin property ismine dikkat etmelisiniz...

        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM category,int id)
        {
            Category guncellenecek = _db.Categories.Find(id);
            guncellenecek.CategoryName = category.CategoryName;
            guncellenecek.Description = category.Description;
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListCategories");
        }

       
    }
}