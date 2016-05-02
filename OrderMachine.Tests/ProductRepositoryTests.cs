using System.Linq;
using FakeItEasy;
using Xunit;

namespace OrderMachine.Tests
{
    [Trait("Category", "ProductRepository")]
    public class ProductRepositoryTests
    {

        [Fact(DisplayName = "Check the performance by using the cache")]
        public void PerformanceByCacheCheck()
        {
            var productRepository = A.Fake<IProductRepository>();
            var cache = A.Fake<ICache>();
            var stopwatch = A.Fake<IStopwatch>();

            IProductRepository repository = new PerformanceMeasuringProductRepository(new CachingProductRepository(productRepository, cache), stopwatch);
            var vm = new TopViewModel(repository);
                        
            Assert.True(vm.TopSellers.Any());
        }
    }
}
