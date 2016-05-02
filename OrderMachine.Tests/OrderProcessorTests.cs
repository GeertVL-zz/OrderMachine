using System;
using System.Diagnostics;
using FakeItEasy;
using Xunit;

namespace OrderMachine.Tests
{
    [Trait("OrderProcessor", "")]
    public class OrderProcessorTests
    {

        [Fact(DisplayName = "Check if OrderProcessor is fast")]
        public void SpecificationName()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var order = new Order();

            var validator = A.Fake<IOrderValidator>();
            A.CallTo(() => validator.Validate(order)).Returns(false);

            var factory = A.Fake<IOrderShipperFactory>();

            var shipper = new LazyOrderShipper(factory);

            var collector = A.Fake<IOrderCollector>();
            
            var sut = new OrderProcessor(validator, shipper, collector);
            sut.Process(order);
            stopwatch.Stop();
            Assert.True(stopwatch.Elapsed < TimeSpan.FromMilliseconds(777));
        }
    }
}
