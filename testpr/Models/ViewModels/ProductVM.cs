using Microsoft.AspNetCore.Mvc.Rendering;

namespace testpr.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { set; get; }
        public IEnumerable<SelectListItem> CatagoryList { get; set; } 
        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
