using MVCModelUsage_0.ViewModels.PureViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCModelUsage_0.ViewModels.PageViewModels
{
    public class ListCategoriesPageVM
    {
        public List<CategoryVM> Categories { get; set; }
        public List<ProductVM> Products { get; set; }
        public List<SupplierVM> Suppliers { get; set; }

    }
}