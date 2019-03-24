using System.Collections.Generic;
using System.Linq;
using DemoApp.Business.TheProduct;
using DemoApp.Business.TheProductMachine;

namespace DemoApp.Business
{
    public static class ExtensionProvider
    {
        public static IEnumerable<Product> GetListProduct(this IEnumerable<ProductManage> products){
            if(products.Count() > 0)
                return products.Select(x=> new Product{ Name = x.Name, size = x.Size, Price = x.Price, Color = x.Color, Detail = x.Detail() }).ToList();
            else
                return new List<Product>();
        }
        public static IEnumerable<ProductMachine> GetListProductMachine(this IEnumerable<ProductMachineManage> products){
            if(products.Count() > 0)
                return products.Select(x=> new ProductMachine{ Name = x.Name, size = x.Size, Price = x.Price, Color = x.Color, Detail = x.Detail(), Ability = x.Ability() }).ToList();
            else
                return new List<ProductMachine>();
        }
    }
}