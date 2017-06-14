using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public class BasketService : IBasketService
    {
        public void DisplayBaskets(List<Basket> baskets)
        {
            foreach (var basket in baskets)
            {
                Console.WriteLine(basket.Name);
            }
        }

        public decimal GetBasketTotal(Basket selectedBasket)
        {
            return selectedBasket.Total = selectedBasket.Products.Sum(m => m.Price * m.Quantity);
        }

        public void ListCurrentBasketItems(Basket selectedBasket)
        {
            Console.WriteLine();
            Console.WriteLine($"Selected Basket: {selectedBasket.Name}");
            Console.WriteLine("--------------------");

            foreach (var product in selectedBasket.Products)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name}: £{product.Price}");
            }
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total: £{GetBasketTotal(selectedBasket)}");
            Console.WriteLine();
        }

        public bool ValidateInput(string selectedBasketInput, List<Basket> basketList, ref Basket selectedBasket)
        {
            int.TryParse(selectedBasketInput, out int basketId);
            selectedBasket = basketList.Where(m => m.Id == basketId).Any() ? basketList.Where(m => m.Id == basketId).FirstOrDefault() : null;

            return selectedBasket != null;
        }
    }
}
