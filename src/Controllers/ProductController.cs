using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Business;
using DemoApp.Business.TheProduct;
using DemoApp.Business.TheProductMachine;
using DemoApp.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork context = new UnitOfWork();
        private List<ProductManage> productList;
        private List<ProductMachineManage> machineList;
        public ProductController(){
            productList = context.ProductsRepository.getData()
            .Select( x =>
                new ProductManage(x.Name,Enum.Parse<Color>(x.Color),Enum.Parse<Size>(x.Size),Int32.Parse(x.Price))
            ).ToList();



            machineList = context.ProductsMachineRepository.getData().Select(x =>
                new ProductMachineManage(x.Name,Enum.Parse<Color>(x.Product.Color),Enum.Parse<Size>(x.Product.Size),x.Clock,x.CostPerClock)
            ).ToList();
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return new List<Product>{ new Product { Name = "Test" } };//productList.GetListProduct();
        }

        [HttpGet("GetColorBlue")]
        public IEnumerable<Product> GetColorBlue()
        {
            var filterColor = new ProductFilter();
            var productColorBlue = filterColor.Filter(productList,new ColorSpecification(Color.Blue))
                .GetListProduct();
            return productColorBlue;
        }

        [HttpGet("GetSizeSmall")]
        public IEnumerable<Product> GetSizeSmall()
        {
            var filterSize = new ProductFilter();
            var productSizeSmall = filterSize.Filter(productList,new SizeSpecification(Size.Small))
                .GetListProduct();
            return productSizeSmall;
        }

        [HttpGet("GetSizeMediumAndColorBlue")]
        public IEnumerable<Product> GetSizeMediumAndColorBlue(){
            var filterSmallAndBlue = new ProductFilter();
            var productMediumAndBlue = filterSmallAndBlue.Filter(productList,new AndSpecification(
                new List<ISpecification<ProductManage>>{ new ColorSpecification(Color.Blue) , new SizeSpecification(Size.Midium) })
            )
            .GetListProduct();
            return productMediumAndBlue;
        }

        [HttpGet("GetSizeMediumAndColorBlack")]
        public IEnumerable<Product> GetSizeMediumAndColorBlack(){
            var filterSmallAndBlue = new ProductFilter();
            var productMediumAndBlue = filterSmallAndBlue.Filter(productList,new AndSpecification(
                new List<ISpecification<ProductManage>>{ new ColorSpecification(Color.Black) , new SizeSpecification(Size.Midium) })
            )
            .GetListProduct();
            return productMediumAndBlue;
        }

        [HttpGet("GetMachine")]
        public IEnumerable<ProductMachine> GetMachine()
        {
            return machineList.GetListProductMachine();
        }
    
        [HttpGet("Insert")]
        public int InsertData(){
            using(var unitOfWork = new UnitOfWork()){
                // unitOfWork.ProductsRepository.insertEntity(
                //     new Products{ Name = "M1", Size="2",Color="2" }
                // );
                // return unitOfWork.SaveContext();
                unitOfWork.ProductsMachineRepository.insertEntity(
                    new ProductsMachine{ Name = "M1",Clock = 1,CostPerClock = 300}
                );
                return unitOfWork.SaveContext();
            }
        }
    }
}
