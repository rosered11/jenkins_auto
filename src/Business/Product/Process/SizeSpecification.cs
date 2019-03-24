using System;
using System.Collections.Generic;

namespace DemoApp.Business.TheProduct
{
    internal class SizeSpecification : ISpecification<ProductManage>
    {
        private Size size;
        internal SizeSpecification(Size size){
            this.size = size;
        }
        public bool IsSatisfied(ProductManage p)
        {
            return Enum.GetName(typeof(Size),this.size) == p.Size;
        }
    }
}