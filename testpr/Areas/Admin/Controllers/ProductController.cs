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
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            //IEnumerable<Product> objCategoryList = _unitOfWork.prorducts.GetAll();
            return View();
        }

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
                var existingValue = _unitOfWork.prorducts.GetFirstOrDefault(u => u.Id == id);
                productVM.Product = existingValue;
                return View(productVM);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _hostEnvironment.WebRootPath;
                if (file != null) // it means that the file is uploaded
                {
                    string fileName = Guid.NewGuid().ToString();
                    var path = Path.Combine(rootPath, @"images\products");
                    var extention = Path.GetExtension(file.FileName);

                    using (var filestreams = new FileStream(Path.Combine(path, fileName + extention), FileMode.Create))
                    {
                        file.CopyTo(filestreams);
                    }
                    obj.Product.ImageUrl = @"images\productsproducts\" + fileName + extention;
                }
                _unitOfWork.prorducts.Add(obj.Product);
                
                _unitOfWork.Save();
                TempData["success"] = "file created successfully successfully";
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
        #region api calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.prorducts.GetAll(inclueProperties:"Category,CoverType");
            return Json(new { data = productList});
        }

        #endregion

    }

}

