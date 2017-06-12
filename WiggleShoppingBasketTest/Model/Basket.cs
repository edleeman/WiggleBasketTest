using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiggleShoppingBasketTest.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
        public List<Product> Products { get; set; }
        public List<GiftVoucher> GiftVouchers { get; set; }
        public List<OfferVoucher> OfferVouchers { get; set; }
    }
}
