using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DemoApp.Business.TheProduct;

[assembly: InternalsVisibleTo("DemoAppTest")]
namespace DemoApp.Business.TheProductMachine
{
    public class ProductMachineManage : ProductManage, IProduct, IMachine
    {
        private int Clock;
        private int CostPerClock;
        public override double Price {
            get{
                return Clock * CostPerClock + 100;
            }
        }
        internal ProductMachineManage(string name, Color color, Size size,int clock,int CostPerClock) : base(name, color, size,0)
        {
            this.Clock = clock;
            this.CostPerClock = CostPerClock;
        }

        public string Ability()
        {
            return $"The {this.Name} can execute.";
        }
    }
}