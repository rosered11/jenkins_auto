using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace DemoAppTest
{
    [CollectionDefinition("Test Collection")]
    public class ImplFixture : ICollectionFixture<TheFixture>
    {
    }
    public class TheFixture
    {
        public IFixture Fixture;
        public DbContextFixture _db;

        public TheFixture()
        {
            _db = new DbContextFixture();
            //Contain all dependency mocking using Moq
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            //using sqlite for DB mocking
            Fixture.Register(() => _db.databaseContext);
            //HttpHelper.Configure(Fixture.Create<IHttpContextAccessor>());
        }
    }

    public static class HttpHelper
    {
        private static IHttpContextAccessor _accessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;

        public static async Task<string> GetAuthToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }
    }
}