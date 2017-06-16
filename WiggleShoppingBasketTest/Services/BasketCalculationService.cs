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
        public VoucherConfirmation AddVoucherToBasket(Basket selectedBasket, Voucher voucher)
        {
            selectedBasket.RunningTotal = selectedBasket.Total;
            var voucherConformation = new VoucherConfirmation();
            selectedBasket.AppliedVouchers = new List<Voucher>();

            if (voucher.VoucherCode == TextConstants.GiftCode && selectedBasket.Products.Any(m => m.Category != "Gift Card"))
            {
                selectedBasket.RunningTotal -= voucher.Discount;
                selectedBasket.AppliedVouchers.Add(voucher);
                voucherConformation.Applied = true;
                return voucherConformation;
            }

            if (voucher.VoucherCode == TextConstants.OfferCode || voucher.VoucherCode == TextConstants.HeadGearOfferCode) 
            {
                selectedBasket.AppliedVouchers = new List<Voucher>();
                if (selectedBasket.AppliedVouchers.Count > 0)
                {
                    voucherConformation.Message = "Only one Offer Voucher can be used";
                    voucherConformation.Applied = false;
                    return voucherConformation;
                }

                if (selectedBasket.Total >= 50.00M) //ToDo make this var
                {
                    if (voucher.VoucherCode == TextConstants.HeadGearOfferCode && selectedBasket.Products.Where(m => m.Category == "Head Gear").Count() == 0)
                    {
                        voucherConformation.Message =  $"There are no products in your basket applicable to voucher {voucher.VoucherCode}";
                        voucherConformation.Applied = false;
                        return voucherConformation;
                    }
                }

                if (selectedBasket.Total < 50.00M) 
                {
                    decimal difference = (50.00M - selectedBasket.Products.Sum(m => m.Price));
                    voucherConformation.Message = $"You have not reached the spend threshold for voucher {voucher.VoucherCode}. Spend another {difference} to receive £{voucher.Discount} discount from your basket total.";
                    voucherConformation.Applied = false;
                    return voucherConformation;
                }

                selectedBasket.AppliedVouchers.Add(voucher);
                voucherConformation.Applied = true;
            }
            return voucherConformation;
        }

        public bool GetTotalForBasket(ref Basket selectedBasket)
        {
            {
                if (selectedBasket == null || selectedBasket.Products == null) return false;

                if (selectedBasket.AppliedVouchers != null && selectedBasket.AppliedVouchers.Count > 0)
                {
                    var headGearVoucher = selectedBasket.AppliedVouchers.Where(v => v.VoucherCode == TextConstants.HeadGearOfferCode).FirstOrDefault();
                    if (headGearVoucher != null)
                    {
                        var headGearProducts = selectedBasket.Products.Where(p => p.Category == "Head Gear");
                        var headgearTotal = headGearProducts.Sum(p => (p.Price * p.Quantity));

                        if (headgearTotal < headGearVoucher.Discount)
                        {
                            selectedBasket.Total = ((selectedBasket.Products.Where(p => p.Category != "Head Gear")
                                .Sum(p => (p.Price * p.Quantity))) - (selectedBasket.AppliedVouchers.Where(v => v.VoucherCode != TextConstants.HeadGearOfferCode).Sum(v => v.Discount)));
                            return true;
                        }
                    }

                    selectedBasket.Total = ((selectedBasket.Products.Sum(p => (p.Price * p.Quantity))) - (selectedBasket.AppliedVouchers.Sum(v => v.Discount)));
                    return true;
                }

                selectedBasket.Total = selectedBasket.Products.Sum(p => (p.Price * p.Quantity));

                return true;
            }
        }
    }
}
