using Microsoft.AspNetCore.Mvc;
using testpr.Data;
using testpr.Models;

namespace testpr.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories;
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
