using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public interface IVoucherService
    {
        void RetrieveAndProcessVoucherCode(Basket selectedBasket);
    }
}
