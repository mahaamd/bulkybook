using Microsoft.AspNetCore.Mvc;
using testpr.Data;
using testpr.Models;
using testpr.Repository;
using testpr.Repository.IRepository;

namespace testpr.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;
        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Category.GetAll();
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
                _db.Category.Add(obj);
                _db.Save();
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
            var categoryFromDb = _db.Category.GetFirstOrDefault(u => u.Id == id);
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
                _db.Category.Update(obj);
                _db.Save();
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
            var categoryFromDb = _db.Category.GetFirstOrDefault(u=> u.Id == id);
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
            var categoryFromDb = _db.Category.GetFirstOrDefault(u => u.Id == id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _db.Category.Remove(categoryFromDb);
            _db.Save();
            TempData["success"] = "data removed successfully";
            return RedirectToAction("Index");


        }
    }

}

