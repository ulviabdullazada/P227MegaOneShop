using MegaOneShop.Models;
using System.Collections.Generic;

namespace MegaOneShop.ViewModels
{
    public class HomeVM
    {
        public List<Product> Top6 { get; set; }
        public List<Product> Lastest { get; set; }
    }
}
