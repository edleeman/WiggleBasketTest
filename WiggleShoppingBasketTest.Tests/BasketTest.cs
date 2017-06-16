using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WiggleShoppingBasketTest.Model;
using System.Collections.Generic;
using WiggleShoppingBasketTest.Repository;
using WiggleShoppingBasketTest.App;
using WiggleShoppingBasketTest.Services;
using System.Linq;
using NUnit;
using Rhino.Mocks;

namespace WiggleShoppingBasketTest.Tests
{
    [TestClass]
    public class BasketTest
    {
        private IBasketData _basketData { get; set; }
        private IVoucherData _voucherData { get; set; }
        private IBasketCalculationService _basketCalculationService { get; set; }
        private List<Voucher> _voucherList { get; set; }
        private List<Basket> _basketList { get; set; }

        [TestInitialize]
        public void Setup()
        {
            _basketData = new BasketData();
            _voucherData = new VoucherData();
            _voucherList = _voucherData.InitializeVouchers();
            _basketList = _basketData.InitializeBaskets();
        }

        [TestMethod]
        public void Basket1Scenario()
        {
            // Arrange
            IBasketCalculationService _basketCalculationService = new BasketCalculationService();
            IBasketService _basketService = new BasketService();

            var voucher = _voucherList.Where(m => m.VoucherCode == "XXX-XXX").FirstOrDefault();
            var basket = _basketList.Where(m => m.Id == 1).FirstOrDefault();
            // Act
            _basketService.GetBasketTotal(basket);
            var voucherConfirmation = _basketCalculationService.AddVoucherToBasket(basket, voucher);

            // Assert
            Assert.IsTrue(voucherConfirmation.Applied);
            Assert.IsTrue(basket.AppliedVouchers.Count > 0);
            Assert.AreEqual(basket.Total, 60.15M);
        }

        [TestMethod]
        public void Basket2Scenario()
        {
            // Arrange
            IBasketCalculationService _basketCalculationService = new BasketCalculationService();
            IBasketService _basketService = new BasketService();

            var voucher = _voucherList.Where(m => m.VoucherCode == "HEADYYY-YYY").FirstOrDefault();
            var basket = _basketList.Where(m => m.Id == 2).FirstOrDefault();

            // Act
            _basketService.GetBasketTotal(basket);
            var voucherConfirmation = _basketCalculationService.AddVoucherToBasket(basket, voucher);

            // Assert
            Assert.IsFalse(voucherConfirmation.Applied);
            Assert.AreEqual(voucherConfirmation.Message, "There are no products in your basket applicable to voucher HEADYYY-YYY");
            Assert.AreEqual(basket.Total, 51);
        }

        [TestMethod]
        public void Basket3Scenario()
        {
            // Arrange
            IBasketCalculationService _basketCalculationService = new BasketCalculationService();
            IBasketService _basketService = new BasketService();

            var voucher = _voucherList.Where(m => m.VoucherCode == "HEADYYY-YYY").FirstOrDefault();
            var basket = _basketList.Where(m => m.Id == 3).FirstOrDefault();

            // Act
            _basketService.GetBasketTotal(basket);
            var voucherConfirmation = _basketCalculationService.AddVoucherToBasket(basket, voucher);
            var foo = _basketCalculationService.GetTotalForBasket(ref basket);
            // Assert
            Assert.IsTrue(foo);
            Assert.AreEqual(basket.Total, 51);
        }

        [TestMethod]
        public void Basket4Scenario()
        {
            // Arrange
            IBasketCalculationService _basketCalculationService = new BasketCalculationService();
            IBasketService _basketService = new BasketService();

            var voucher = _voucherList.Where(m => m.VoucherCode == "YYY-YYY").FirstOrDefault();
            var voucher2 = _voucherList.Where(m => m.VoucherCode == "XXX-XXX").FirstOrDefault();
            var basket = _basketList.Where(m => m.Id == 4).FirstOrDefault();

            // Act
            _basketService.GetBasketTotal(basket);
            _basketCalculationService.AddVoucherToBasket(basket, voucher);
            _basketCalculationService.AddVoucherToBasket(basket, voucher2);
            var foo = _basketCalculationService.GetTotalForBasket(ref basket);

            // Assert
            Assert.IsTrue(foo);
            Assert.AreEqual(basket.Total, 41);
        }

        [TestMethod]
        public void Basket5Scenario()
        {
            // Arrange
            IBasketCalculationService _basketCalculationService = new BasketCalculationService();
            IBasketService _basketService = new BasketService();

            var voucher = _voucherList.Where(m => m.VoucherCode == "YYY-YYY").FirstOrDefault();
            var basket = _basketList.Where(m => m.Id == 5).FirstOrDefault();

            // Act
            _basketService.GetBasketTotal(basket);
            var voucherConfirmation = _basketCalculationService.AddVoucherToBasket(basket, voucher);

            // Assert
            Assert.AreEqual(voucherConfirmation.Message, "You have not reached the spend threshold for voucher YYY-YYY. Spend another £25.00 to receive £5.00 discount from your basket total.");
            Assert.AreEqual(basket.Total, 55);
        }
    }
}
