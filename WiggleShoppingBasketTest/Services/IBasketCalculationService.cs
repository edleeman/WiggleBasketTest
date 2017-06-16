using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public interface IBasketCalculationService
    {
        VoucherConfirmation AddVoucherToBasket(Basket selectedBasket, Voucher voucher);
        bool GetTotalForBasket(ref Basket selectedBasket);
    }
}
