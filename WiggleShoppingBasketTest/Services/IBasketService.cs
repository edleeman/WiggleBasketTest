using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public partial interface IBasketService
    {
        void DisplayBaskets(List<Basket> baskets);
        void ListCurrentBasketItems(Basket selectedBasket);
        decimal GetBasketTotal(Basket selectedBasket);
        bool ValidateInput(string selectedBasketInput, List<Basket> basketList, ref Basket selectedBasket);
    }
}
