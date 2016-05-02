using System;
using System.Collections.Generic;

namespace OrderMachine
{
    public class PerformanceMeasuringProductRepository : IProductRepository
    {
        private readonly IProductRepository _repository;
        private readonly IStopwatch _stopwatch;

        public PerformanceMeasuringProductRepository(IProductRepository repository, IStopwatch stopwatch)
        {            
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (stopwatch == null) throw new ArgumentNullException(nameof(stopwatch));
            _repository = repository;
            _stopwatch = stopwatch;
        }

        public IEnumerable<Product> SelectTopSellers()
        {
            var timer = _stopwatch.StartMeasuring("SelectTopSellers");
            var topSellers = _repository.SelectTopSellers();
            timer.StopMeasuring();
            return topSellers;
        }
    }
}