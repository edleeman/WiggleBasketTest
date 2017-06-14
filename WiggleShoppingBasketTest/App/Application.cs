using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Data;
using WiggleShoppingBasketTest.Model;
using WiggleShoppingBasketTest.Services;

namespace WiggleShoppingBasketTest.App
{
    public class Application : IApplication
    {
        private readonly IBasketService _basketService;
        private readonly IBasketData _basketData;
        private readonly IVoucherService _voucherService;

        public Application(IBasketService basketService, IBasketData basketData, IVoucherService voucherService)
        {
            _basketService = basketService;
            _voucherService = voucherService;
            _basketData = basketData;
        }

        public void Run()
        {
            List<Basket> basketList = _basketData.InitializeBaskets();
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
                _voucherService.RetrieveAndProcessVoucherCode(selectedBasket);
            }

            Console.ReadKey();
        }
    }
}
