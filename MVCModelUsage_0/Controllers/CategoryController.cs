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
    }
}