using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using testpr.Data;
using testpr.Models;
using testpr.Models.ViewModels;
using testpr.Repository;
using testpr.Repository.IRepository;

namespace testpr.Areas.Admin.Controllers
{
//[Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objCategoryList = _unitOfWork.prorducts.GetAll();
            return View(objCategoryList);
        }

        // GET
        

        // GET
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CatagoryList = _unitOfWork.Category.GetAll().Select(
                 u => new SelectListItem
                 {
                     Text = u.Name,
                     Value = u.Id.ToString()
                 }),
                CoverTypeList = _unitOfWork.CovreTypes.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                //creata product
                //ViewBag.CategoryList = productVM.CatagoryList;
                //ViewData["CoverTypeList"] = productVM.CoverTypeList;
                return View(productVM);
            }
            else
            {
                // add product
            }
            
            return View(productVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //_unitOfWork.prorducts.update(obj);
                _unitOfWork.Save();
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
            var CoverTypeFromDb = _unitOfWork.prorducts.GetFirstOrDefault(u => u.Id == id);
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
            var ProductFromDb = _unitOfWork.prorducts.GetFirstOrDefault(u => u.Id == id);

            if (ProductFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.prorducts.Remove(ProductFromDb);
            _unitOfWork.Save();
            TempData["success"] = "data removed successfully";
            return RedirectToAction("Index");


        }
    }

}

