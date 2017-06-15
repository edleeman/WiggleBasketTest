using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Constants;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Services
{
    public class BasketCalculationService : IBasketCalculationService
    {
        public void ApplyDiscount(Basket selectedBasket, Voucher voucher)
        {
            selectedBasket.RunningTotal = selectedBasket.Total;

            if (voucher.VoucherCode == TextConstants.GiftCode && selectedBasket.Products.Any(m => m.Category != "Gift Card"))
            {
                selectedBasket.RunningTotal -= voucher.Discount;
            }

            if (voucher.VoucherCode == TextConstants.OfferCode || voucher.VoucherCode == TextConstants.HeadGearOfferCode) 
            {
                selectedBasket.AppliedOfferVouchers = new List<OfferVoucher>();
                if (selectedBasket.AppliedOfferVouchers.Count > 0)
                {
                    Console.WriteLine("Only one Offer Voucher can be used");
                }

                if (selectedBasket.Total >= 50.00M) //ToDo make this var
                {
                    if (voucher.VoucherCode == TextConstants.HeadGearOfferCode && selectedBasket.Products.Where(m => m.Category == "Head Gear").Count() == 0)
                    {
                        Console.WriteLine($"There are no products in your basket applicable to voucher {voucher.VoucherCode}");
                    }
                }
                else
                {
                    decimal difference = (50.00M - selectedBasket.Products.Sum(m => m.Price));
                    Console.WriteLine($"You have not reached the spend threshold for voucher {voucher.VoucherCode}. Spend another {difference} to receive £{voucher.Discount} discount from your basket total.");
                }

                if (selectedBasket.RunningTotal != selectedBasket.Total)
                {
                    selectedBasket.AppliedOfferVouchers.Add((OfferVoucher)voucher);
                }
            }
        }
    }
}
