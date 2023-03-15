using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCModelUsage_0.ViewModels.PureViewModels
{
    public class ProductVM
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }

    }
}