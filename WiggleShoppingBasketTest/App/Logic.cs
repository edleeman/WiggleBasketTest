using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.App
{
    public class Logic
    {

        internal static List<Basket> InitializeBaskets() {
            List<Basket> _basketList = new List<Basket>()
            {
                new Basket(){
                    Id = 1,
                    Name = "Basket 1",
                    Products = new List<Product>()
                    {
                        new Product(){
                            Name = "Hat",
                            Price = 10.50M,
                            Quantity = 1
                        },
                        new Product(){
                            Name = "Jumper",
                            Price = 54.65M,
                            Quantity = 1
                        }
                    }
                },
                new Basket(){
                    Id = 2,
                    Name = "Basket 2",
                    Products = new List<Product>()
                    {
                        new Product(){
                            Name = "Hat",
                            Price = 25.00M,
                            Quantity = 1
                        },
                        new Product(){
                            Name = "Jumper",
                            Price = 26.00M,
                            Quantity = 1
                        }
                    }
                },
                new Basket(){
                    Id = 3,
                    Name = "Basket 3",
                    Products = new List<Product>()
                    {
                        new Product(){
                            Name = "Hat",
                            Price = 25.00M,
                            Quantity = 1
                        },
                        new Product(){
                            Name = "Jumper",
                            Price = 26.00M,
                            Quantity = 1
                        },
                        new Product(){
                            Name = "Head Light",
                            Price = 3.50M,
                            Quantity = 1
                        }
                    }
                },
                new Basket(){
                    Id = 4,
                    Name = "Basket 4",
                    Products = new List<Product>()
                    {
                        new Product(){
                            Name = "Hat",
                            Price = 25.00M,
                            Quantity = 1
                        },
                        new Product(){
                            Name = "Jumper",
                            Price = 26.00M,
                            Quantity = 1
                        }
                    }
                },
                new Basket(){
                    Id = 5,
                    Name = "Basket 5",
                    Products = new List<Product>()
                    {
                        new Product(){
                            Name = "Hat",
                            Price = 25.00M,
                            Quantity = 1
                        },
                        new Product(){
                            Name = "£30 Gift Voucher",
                            Price = 30.00M,
                            Quantity = 1
                        }
                    }
                }
            };

            return _basketList;
        }

        internal static void DisplayBaskets(List<Basket> baskets)
        {
            foreach (var basket in baskets)
            {
                Console.WriteLine(basket.Name);
            }
        }

        internal static bool ValidateInput(string selectedBasketInput, List<Basket> basketList, ref Basket selectedBasket)
        {
            int.TryParse(selectedBasketInput, out int basketId);
            selectedBasket = basketList.Where(m => m.Id == basketId).Any() ? basketList.Where(m => m.Id == basketId).FirstOrDefault() : null;

            return selectedBasket != null;
        }

        internal static void ListCurrentBasketItems(Basket selectedBasket)
        {
            Console.WriteLine();
            Console.WriteLine($"Selected Basket: {selectedBasket.Name}");
            Console.WriteLine("--------------------");

            foreach (var product in selectedBasket.Products)
            {
                Console.WriteLine($"{product.Quantity} x {product.Name}: £{product.Price}");
            }
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total: £{GetTotal(selectedBasket)}");
            Console.WriteLine();
        }

        internal static void RetrieveAndProcessVoucherCode(Basket selectedBasket)
        {
            Console.WriteLine("Please enter your voucher code:");
            bool processed = false;
            while (!processed)
            {
                processed = ProcessVoucherCode(Console.ReadLine(), selectedBasket);
            }
        }

        private static bool ProcessVoucherCode(string voucherCode, Basket selectedBasket)
        {
            var voucherTuple = InitializeVouchers();

            switch (voucherCode.ToUpper())
            {
                case "XXX-XXX":
                    List<GiftVoucher> giftVouchers = voucherTuple.Item1;
                    ApplyDiscount(selectedBasket);
                    return true;
                case "YYY-YYY":
                    List<OfferVoucher> offerVouchers = voucherTuple.Item2;
                    ApplyDiscount(selectedBasket);
                    return true;
                default:
                    Console.WriteLine("Invalid voucher code - please try again");
                    return false;
            }
        }

        private static void ApplyDiscount(Basket selectedBasket)
        {
            throw new NotImplementedException();
        }

        private static Tuple<List<GiftVoucher>, List<OfferVoucher>> InitializeVouchers()
        {
            List<GiftVoucher> _giftVouchers = new List<GiftVoucher>()
            {
                new GiftVoucher()
                {
                    VoucherCode = "XXX-XXX",
                    Discount = 5.00M
                }
            };

            List<OfferVoucher> _offerVouchers = new List<OfferVoucher>()
            {
                new OfferVoucher()
                {
                    VoucherCode = "YYY-YYY",
                    Discount = 5.00M,
                    MinimumSpend = 50.00M
                }
            };

            return Tuple.Create<List<GiftVoucher>, List<OfferVoucher>>(_giftVouchers, _offerVouchers);
        }

        private static decimal GetTotal(Basket selectedBasket)
        {
            return selectedBasket.Total = selectedBasket.Products.Sum(m => m.Price * m.Quantity);
        }
    }
}
