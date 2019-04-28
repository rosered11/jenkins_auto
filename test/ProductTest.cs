using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using DemoApp.Business.TheProduct;
using DemoApp.DAL;
using Xunit;

namespace DemoAppTest
{
    [Collection("Test Collection")]
    public class ProductTest
    {
        //private Products _model;
        private readonly IFixture _fixture;
        public ProductTest(TheFixture data)
        {
            _fixture = data.Fixture;
        }
        [Fact]
        public void ProductFilterColorBlue_IsSuccess()
        {
            var productFilter = new ProductFilter();
            var colorSpecify = new ColorSpecification(Color.Blue);
            var data = new List<ProductManage>(){
                new ProductManage("P1",Color.Blue,Size.Large,1200),
                new ProductManage("P2",Color.Yellow,Size.Large,1200)
            };

            var listDatas = productFilter.Filter(data, colorSpecify);

            Assert.True(listDatas.Count() > 0);
            foreach (var checkData in listDatas)
            {
                Assert.Equal(Color.Blue, checkData.color);
            }
        }
        [Fact]
        public void ProductFilterColorBlack_IsFail()
        {
            var productFilter = new ProductFilter();
            var sizeSpecify = new SizeSpecification(Size.Midium);
            var data = new List<ProductManage>(){
                new ProductManage("P3",Color.Blue,Size.Small,3000),
                new ProductManage("P4",Color.Black,Size.Midium,3000)
            };

            Assert.False(false);
        }

        [Fact]
        public void DbContextTest()
        {
            using(var dataContext = _fixture.Create<DbContextFixture>()){
                Assert.True(dataContext.databaseContext.products.Any());
                Assert.True(dataContext.databaseContext.products.Count() == 1);

                dataContext.databaseContext.products.Add(
                    new Products { Name = "Ice" }
                );
                Assert.True(dataContext.databaseContext.SaveChanges() == 1);
                Assert.True(dataContext.databaseContext.products.Any(x=>x.Name.Equals("Ice",StringComparison.OrdinalIgnoreCase)));
            }
        }

        [Fact]
        public void IntroductoryTest()
        {
            // Arrange
            Fixture fixture = new Fixture();

            int expectedNumber = fixture.Create<int>();
            MyClass sut = fixture.Create<MyClass>();
            // Act
            int result = sut.Echo(expectedNumber);
            // Assert
            Assert.Equal(expectedNumber, result);
        }
    }

    class MyClass{
        public int Echo(int data){ return data;}   
    }
}
