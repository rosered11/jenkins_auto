using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DemoAppTest")]
namespace DemoApp.Business.TheProduct
{
    public class ProductManage : IProduct
    {
        public string Name {get;}
        public Size size {get;}
        public Color color {get;}
        public virtual double Price {get;}
        public string Size{
            get{
                return Enum.GetName(typeof(Size),size);
            }
        }
        public string Color{
            get{
                return Enum.GetName(typeof(Color),this.color);
            }
        }
        internal ProductManage(string name, Color color, Size size,double price)
        {
            Name = name;
            this.color = color;
            this.size = size;
            this.Price = price;
        }

        public string Detail()
        {
            return $"{this.Name} color is {this.Color} and size is {this.Size}.";
        }
    }

    internal class ProductFilter : IFilter<ProductManage>
    {
        public IEnumerable<ProductManage> Filter(IEnumerable<ProductManage> items, ISpecification<ProductManage> spec)
        {
            foreach(var data in items){
                if(spec.IsSatisfied(data))
                {
                    yield return data;
                }
            }
        }
    }
}