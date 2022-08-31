using MegaOneShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MegaOneShop.Controllers
{
    public class AdminController : Controller
    {
        private List<Product> products;
        public AdminController()
        {
            using (StreamReader sr = new StreamReader("C:\\Users\\Ülvi\\Desktop\\P326-master\\MegaOneShop\\MegaOneShop\\Files\\products.json"))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProduct()
        {
            return View(products);
        }
        public IActionResult Product()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Product(Product product)
        {
            if (product.NewPrice >= product.OldPrice) return View();
            if (!System.IO.File.Exists("C:\\Users\\Ülvi\\Desktop\\P326-master\\MegaOneShop\\MegaOneShop\\wwwroot\\shop\\img\\"+product.ImageUrl)) return View();
            product.Id = products.FindLast(x=> true).Id+1;
            products.Add(product);
            SaveProducts();
            return RedirectToAction(nameof(GetProduct));
        }
        //public void AddProducts()
        //{
        //    List<Product> products = new List<Product>();
        //    products.Add(new Product { Id = 1, Name = "Nike 1", NewPrice = 120, OldPrice = 140, Subtitle = "", ImageUrl = "nike.webp" });
        //    products.Add(new Product { Id = 2, Name = "Jordan", NewPrice = 100, OldPrice = 140, Subtitle = "", ImageUrl = "jordan.webp" });
        //    using (StreamWriter sw = new StreamWriter("C:\\Users\\Ülvi\\Desktop\\P326-master\\MegaOneShop\\MegaOneShop\\Files\\products.json"))
        //    {
        //        sw.Write(JsonConvert.SerializeObject(products));
        //    }
        //}
        private void SaveProducts()
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Ülvi\\Desktop\\P326-master\\MegaOneShop\\MegaOneShop\\Files\\products.json"))
            {
                sw.Write(JsonConvert.SerializeObject(products));
            }
        }
    }
}
