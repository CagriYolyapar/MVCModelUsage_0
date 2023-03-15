using MVCModelUsage_0.ViewModels.PureViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCModelUsage_0.ViewModels.PageViewModels
{
    public class AddProductPageVM
    {
        public ProductVM Product { get; set; }
        public List<CategoryVM> Categories { get; set; }

    }
}