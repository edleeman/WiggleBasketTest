using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Data
{
    public interface IBasketData
    {
        List<Basket> InitializeBaskets();
    }
}
