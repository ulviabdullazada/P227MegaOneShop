using MegaOneShop.Models;
using MegaOneShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MegaOneShop.Controllers
{
    public class HomeController : Controller
    {
        private List<Product> products;
        public HomeController()
        {
            using (StreamReader sr = new StreamReader("C:\\Users\\Ülvi\\Desktop\\P326-master\\MegaOneShop\\MegaOneShop\\Files\\products.json"))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
            }
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM { Top6 = TopProducts(products, 6)};
            products.Reverse();
            homeVM.Lastest = TopProducts(products, 4);
            return View(homeVM);
        }
        private List<Product> TopProducts(List<Product> products, int max)
        {
            if (max > products.Count) max = products.Count;
            List<Product> newProducts = new List<Product>();
            for (int i = 0; i < max; i++)
            {
                newProducts.Add(products[i]);
            }
            return newProducts;
        }
    }
}
