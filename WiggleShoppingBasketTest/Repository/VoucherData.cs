using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Repository
{
    public class VoucherData : IVoucherData
    {
        public List<Voucher> InitializeVouchers()
        {
            List<Voucher> voucherList = new List<Voucher>()
            {
                new OfferVoucher()
                {
                    Discount = 5.00M,
                    MinimumSpend = 50.00M,
                    VoucherCode = "YYY-YYY"
                },
                new OfferVoucher()
                {
                    Discount = 5.00M,
                    MinimumSpend = 50.00M,
                    VoucherCode = "HEADYYY-YYY"
                },
                new GiftVoucher()
                {
                    Discount = 5.00M,
                    VoucherCode = "XXX-XXX"
                }
            };

            return voucherList;
        }
    }
}
