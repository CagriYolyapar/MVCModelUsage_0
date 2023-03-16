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
    public class ProductController : Controller
    {
        NorthwindEntities _db;

        public ProductController()
        {
            _db = DBTool.DBInstance;
        }




        public ActionResult ListProducts()
        {
            List<ProductVM> products = GetProductsAsVM();
            ListProductsPageVM lpvm = new ListProductsPageVM
            {
                Products = products
            };

            return View(lpvm);
        }

        public ActionResult AddProduct()
        {
            List<CategoryVM> categories = GetCategoriesAsVM();
            AddUpdateProductPageVM apvm = new AddUpdateProductPageVM
            {
                Categories = categories
            };
            return View(apvm);
        }


        [HttpPost]
        public ActionResult AddProduct(ProductVM product)
        {
            Product p = new Product
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryID = product.CategoryID,    
            };
            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }


       

        public ActionResult UpdateProduct(int id)
        {
            List<CategoryVM> categories = GetCategoriesAsVM();
            AddUpdateProductPageVM apvm = new AddUpdateProductPageVM
            {
                Categories = categories,
                Product = _db.Products.Where(x=>x.ProductID == id).Select(x=> new ProductVM
                {
                    ID = x.ProductID,
                    ProductName = x.ProductName,
                    CategoryID = x.CategoryID,
                    UnitPrice = x.UnitPrice
                }).FirstOrDefault()
            };
            return View(apvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductVM product,int id)
        {
           
            Product guncellenecek = _db.Products.Find(id);
            guncellenecek.ProductName = product.ProductName;
            guncellenecek.UnitPrice = product.UnitPrice;
            guncellenecek.CategoryID = product.CategoryID;
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public ActionResult DeleteProduct(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        private List<ProductVM> GetProductsAsVM()
        {
            return _db.Products.Select(x => new ProductVM
            {
                ID = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category.CategoryName
            }).ToList();
        }

        private List<CategoryVM> GetCategoriesAsVM()
        {
            return _db.Categories.Select(x => new CategoryVM
            {
                ID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
               
            }).ToList();
        }


    }
}