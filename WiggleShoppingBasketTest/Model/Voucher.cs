using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiggleShoppingBasketTest.Model
{
    public class Voucher
    {
        public string VoucherCode { get; set; }
        public decimal Discount { get; set; }
        public int VoucherType { get; set; }
    }
}
