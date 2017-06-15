using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiggleShoppingBasketTest.App;
using WiggleShoppingBasketTest.Model;
using WiggleShoppingBasketTest.Services;
using WiggleShoppingBasketTest.Repository;

namespace WiggleShoppingBasketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<BasketService>().As<IBasketService>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<BasketData>().As<IBasketData>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<VoucherData>().As<IVoucherData>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<BasketCalculationService>().As<IBasketCalculationService>().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<VoucherService>().As<IVoucherService>().SingleInstance().PreserveExistingDefaults();

            var container = builder.Build();
            container.Resolve<IApplication>().Run();
        }    
    }
}
