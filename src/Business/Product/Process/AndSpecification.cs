using System.Collections;
using System.Collections.Generic;

namespace DemoApp.Business.TheProduct
{
    internal class AndSpecification : ISpecification<ProductManage>
    {
        private IEnumerable<ISpecification<ProductManage>> specifyList;

        internal AndSpecification(IEnumerable<ISpecification<ProductManage>> specifyList){
            this.specifyList = specifyList;
        }

        public bool IsSatisfied(ProductManage p)
        {
            foreach(var specify in this.specifyList){
                if(!specify.IsSatisfied(p)){
                    return false;
                }
            }
            return true;
        }
    }
}