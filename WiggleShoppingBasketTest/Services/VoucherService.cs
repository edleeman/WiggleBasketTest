using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public class VoucherService : IVoucherService
    {

        public void RetrieveAndProcessVoucherCode(Basket selectedBasket)
        {
            Console.WriteLine("Please enter your voucher code:");
            bool processed = false;
            while (!processed)
            {
                processed = ProcessVoucherCode(Console.ReadLine(), selectedBasket);
            }
        }

        private bool ProcessVoucherCode(string voucherCode, Basket selectedBasket)
        {
            //var voucherTuple = InitializeVouchers();

            //switch (voucherCode.ToUpper())
            //{
            //    case "XXX-XXX":
            //        List<GiftVoucher> giftVouchers = voucherTuple.Item1;
            //        ApplyDiscount(selectedBasket);
            //        return true;
            //    case "YYY-YYY":
            //        List<OfferVoucher> offerVouchers = voucherTuple.Item2;
            //        ApplyDiscount(selectedBasket);
            //        return true;
            //    default:
            //        Console.WriteLine("Invalid voucher code - please try again");
            //        return false;
            //}

            throw new NotImplementedException();
        }

        private static void ApplyDiscount(Basket selectedBasket)
        {
            throw new NotImplementedException();
        }


    }
}
