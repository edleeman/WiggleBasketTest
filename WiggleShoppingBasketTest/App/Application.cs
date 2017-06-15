using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;
using WiggleShoppingBasketTest.Repository;
using WiggleShoppingBasketTest.Services;

namespace WiggleShoppingBasketTest.App
{
    public class Application : IApplication
    {
        private readonly IBasketService _basketService;
        private readonly IBasketCalculationService _basketCalculationService;
        private readonly IBasketData _basketData;
        private readonly IVoucherData _voucherData;
        private readonly IVoucherService _voucherService;

        public Application(IBasketService basketService, IBasketCalculationService basketCalculationService, IBasketData basketData, IVoucherData voucherData, IVoucherService voucherService)
        {
            _basketService = basketService;
            _basketCalculationService = basketCalculationService;
            _voucherService = voucherService;
            _basketData = basketData;
            _voucherData = voucherData;
        }

        public void Run()
        {
            List<Basket> basketList = _basketData.InitializeBaskets();
            List<Voucher> voucherList = _voucherData.InitializeVouchers();
            string selectedBasketInput = string.Empty;
            Basket selectedBasket = new Basket();

            Console.WriteLine("Please select a basket");
            _basketService.DisplayBaskets(basketList);

            selectedBasketInput = Console.ReadLine();

            while (!_basketService.ValidateInput(selectedBasketInput, basketList, ref selectedBasket))
            {
                Console.WriteLine("Invalid Input - Please try again");
                selectedBasketInput = Console.ReadLine();
            }

            Console.Clear();
            _basketService.ListCurrentBasketItems(selectedBasket);

            Console.WriteLine("Would you like to add a voucher? (Y/N)");
            string addVoucher = Console.ReadLine();

            if (addVoucher.ToUpper() == "Y")
            {
                var selectedVoucher = _voucherService.GetSelectedVoucher(selectedBasket, voucherList);
                _basketCalculationService.ApplyDiscount(selectedBasket, selectedVoucher);
            }

            Console.ReadKey();
        }
    }
}
