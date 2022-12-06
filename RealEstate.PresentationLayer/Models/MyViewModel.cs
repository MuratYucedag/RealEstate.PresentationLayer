using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Models
{
    public class MyViewModel
    {
        public MyViewModel()
        {
            advList = new List<Product>();
        }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int TotalCount { get; set; }
        public string OrderBy { get; set; }
        public List<Product> advList { get; set; }
    }
}
