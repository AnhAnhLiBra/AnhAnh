using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWord.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View("ShowAll");
        }
        /*
         * public IActionResult ShowAll()
        {
            ViewData["Heading"] = "All Products";
            var products = new List<Product>();
            products.Add(new Product { ID = 101, Name = "IPad 2018", Price = 499});
            products.Add(new Product { ID = 202, Name = "IPad X", Price = 999 });
            products.Add(new Product { ID = 303, Name = "SS Note 9", Price = 1099 });
            return View(products);
        }
        */
        static List<Product> products = new List<Product>();
        public IActionResult ShowAll()
        {
            return View("ShowAll", products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create([Bind("ID", "Name", "Price")] Product product)
        {
            // thêm vào danh sách 
            products.Add(product);
            // gọi hiển thị danh sách
            return RedirectToAction("ShowAll");
        }

        public IActionResult Edit(int id)
        {
            Product p = products.SingleOrDefault(q => q.ID == id);
            if (p!=null) // tìm thấy 
            {
                return View(p);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID", "Name", "Price")] Product product)
        {
            Product p = products.SingleOrDefault(q => q.ID == id);
            if (p != null) // tìm thấy
            {
                p.Name = product.Name;
                p.Price = product.Price;
            }
            return RedirectToAction("ShowAll");
        }
    }
}