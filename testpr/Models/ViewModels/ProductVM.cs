using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace testpr.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { set; get; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CatagoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
