using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.Model;

namespace WiggleShoppingBasketTest.Repository
{
    public class BasketData : IBasketData
    {
        public List<Basket> InitializeBaskets()
        {
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
                            Quantity = 1,
                            Category = "Head Gear"
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
                            Quantity = 1,
                            Category = "Voucher"
                        }
                    }
                }
            };

            return _basketList;
        }
    }
}
