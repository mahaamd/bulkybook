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

        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("add custoom error", "the display cannot exactly be the same as name");
            }

            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "data added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            // TODO: do not foget to change this part
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("add custoom error", "the display cannot exactly be the same as name");
            }

            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "data edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            // TODO: do not foget to change this part
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var categoryFromDb = _db.categories.Find(id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _db.categories.Remove(categoryFromDb);
            _db.SaveChanges();
            TempData["success"] = "data removed successfully";
            return RedirectToAction("Index");


        }
    }

}

