using System.Threading;
using System.Threading.Tasks;
using Basket.API.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Xunit;

namespace Basket.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = new Mock<IDistributedCache>();
            a.Object.SetString("at","mat");
            // var repo = new BasketRepository(a.Object);
            // // a.Setup(c=>c.GetStringAsync("alma",It.IsAny<CancellationToken>()))
            //     // .ReturnsAsync("at");
            // a.Setup(C => C.ToString()).Returns("ALMA");
            //
            // var result = repo.GetBasket("alma").Result;
            
            a.Setup(c=>c.GetString("at"))
                .Returns("mat");
            var r = a.Object.GetString("at");
            Assert.Equal("mat",r);
        }
    }
}
