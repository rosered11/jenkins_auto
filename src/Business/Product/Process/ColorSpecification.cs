using System;
using System.Collections.Generic;

namespace DemoApp.Business.TheProduct
{
    internal class ColorSpecification : ISpecification<ProductManage>
    {
        private Color color;
        internal ColorSpecification(Color color){
            this.color = color;
        }
        public bool IsSatisfied(ProductManage p)
        {
            return Enum.GetName(typeof(Color),this.color) == p.Color;
        }
    }
}