using Davi.CrudExample.Models;
using Davi.CrudExample.Site.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Davi.CrudExample.Site.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository<Product> _productRepository; 
        private IRepository<Category> _categoryRepository;

        public ProductsController(IRepository<Product> productRepository, IRepository<Category> categoryRespository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRespository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.Get();
            return View(products);
        }

        public IActionResult Details(long id)
        {
            List<SelectListItem> categoriesItems = new List<SelectListItem>();
            var categories = _categoryRepository.Get();
            categories.ToList().ForEach(c => categoriesItems.Add(new SelectListItem { Value = c.Id.ToString(), Text = c.Name }));
            ViewBag.categories = categoriesItems;

            if (id > 0)
            {
                var product = _productRepository.Get(id);
                return View(product);
            }
            return View(new Product());
        }

        [HttpPost]
        public RedirectToActionResult Save(long id, string Name, double price, string description, string imgLink, long categoryId)
        {
            if(id > 0)
            {
                _productRepository.Update(new Product(id, Name, price, description, imgLink, categoryId));
            }
            else
            {
                var product = _productRepository.Create(new Product(0, Name, price, description, imgLink, categoryId));
                id = product.Id;
            }

            return RedirectToAction("Details", new { id = id });
        }

        public RedirectToActionResult Delete(long id)
        {
            _productRepository.Delete(id);

            return RedirectToAction("Index");

        }
    }
}
