﻿using Microsoft.AspNetCore.Mvc;
using testpr.Data;
using testpr.Models;
using testpr.Repository;
using testpr.Repository.IRepository;

namespace testpr.Areas.Admin.Controllers
{
//[Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _db;
        public ProductController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objCategoryList = _db.prorducts.GetAll();
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
        public IActionResult Create(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.prorducts.Add(obj);
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
            var coverTypeFromDb = _db.prorducts.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            // TODO: do not foget to change this part
            return View(coverTypeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.prorducts.update(obj);
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
            var CoverTypeFromDb = _db.prorducts.GetFirstOrDefault(u => u.Id == id);
            if (CoverTypeFromDb == null)
            {
                return NotFound();
            }
            // TODO: do not foget to change this part
            return View(CoverTypeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var ProductFromDb = _db.prorducts.GetFirstOrDefault(u => u.Id == id);

            if (ProductFromDb == null)
            {
                return NotFound();
            }

            _db.prorducts.Remove(ProductFromDb);
            _db.Save();
            TempData["success"] = "data removed successfully";
            return RedirectToAction("Index");


        }
    }

}

