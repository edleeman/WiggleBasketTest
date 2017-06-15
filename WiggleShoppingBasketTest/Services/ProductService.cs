using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetListOfProducts(Basket currentBasket)
        {
            return currentBasket.Products;
        }
    }
}
