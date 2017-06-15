using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Constants;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public class VoucherService : IVoucherService
    {
        public Voucher GetSelectedVoucher (Basket selectedBasket, List<Voucher> voucherList)
        {
            Console.WriteLine("Please enter your voucher code:");
            Voucher selectedVoucher = null;

            while (selectedVoucher == null)
            {
                selectedVoucher = ProcessVoucherCode(Console.ReadLine(), selectedBasket, voucherList, selectedVoucher);
            }

            return selectedVoucher;
        }

        private Voucher ProcessVoucherCode(string voucherCode, Basket selectedBasket, List<Voucher> voucherList, Voucher selectedVoucher)
        {
            switch (voucherCode.ToUpper())
            {
                case TextConstants.GiftCode:
                    selectedVoucher = voucherList.Where(v => v.VoucherCode == TextConstants.GiftCode).FirstOrDefault();
                    break;
                case TextConstants.OfferCode:
                    selectedVoucher = voucherList.Where(v => v.VoucherCode == TextConstants.OfferCode).FirstOrDefault();
                    break;
                case TextConstants.HeadGearOfferCode:
                    selectedVoucher = voucherList.Where(v => v.VoucherCode == TextConstants.HeadGearOfferCode).FirstOrDefault();
                    break;
                default:
                    Console.WriteLine("Invalid voucher code - please try again");
                    break;
            }

            return selectedVoucher;
        }
    }
}
