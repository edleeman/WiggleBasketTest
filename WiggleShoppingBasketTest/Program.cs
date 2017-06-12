using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.App;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Basket> basketList = Logic.InitializeBaskets();
            string selectedBasketInput = string.Empty;
            Basket selectedBasket = new Basket();

            Console.WriteLine("Please select a basket");
            Logic.DisplayBaskets(basketList);

            selectedBasketInput = Console.ReadLine();

            while(!Logic.ValidateInput(selectedBasketInput, basketList, ref selectedBasket))
            {
                Console.WriteLine("Invalid Input - Please try again");
                selectedBasketInput = Console.ReadLine();
            }

            Console.Clear();
            Logic.ListCurrentBasketItems(selectedBasket);

            Console.WriteLine("Would you like to add a voucher? (Y/N)");
            string addVoucher = Console.ReadLine();

            if (addVoucher.ToUpper() == "Y")
            {
                Logic.RetrieveAndProcessVoucherCode(selectedBasket);
            }

            Console.ReadKey();
        }
    }
}
