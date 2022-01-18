using Davi.CrudExample.Models;
using Davi.CrudExample.Site.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Davi.CrudExample.Site.Controllers
{
    public class CategoriesController : Controller
    {
        private IRepository<Category> _categoryRepository;

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.Get();
            return View(categories);
        }

        public IActionResult Details(long id)
        {
            if (id > 0)
            {
                var category = _categoryRepository.Get(id);
                return View(category);
            }
            return View(new Category());
        }

        [HttpPost]
        public RedirectToActionResult Save(long id, string Name)
        {
            if (id > 0)
            {
                _categoryRepository.Update(new Category(id, Name));
            }
            else
            {
                var product = _categoryRepository.Create(new Category(0, Name));
                id = product.Id;
            }

            return RedirectToAction("Details", new { id = id });
        }

        public RedirectToActionResult Delete(long id)
        {
            _categoryRepository.Delete(id);

            return RedirectToAction("Index");

        }
    }
}
