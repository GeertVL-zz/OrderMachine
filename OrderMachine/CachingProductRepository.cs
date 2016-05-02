using System;
using System.Collections.Generic;

namespace OrderMachine
{
    public class CachingProductRepository : IProductRepository
    {
        private readonly IProductRepository _repository;
        private readonly ICache _cache;

        public CachingProductRepository(IProductRepository repository, ICache cache)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (cache == null) throw new ArgumentNullException(nameof(cache));
            _repository = repository;
            _cache = cache;
        }

        public IEnumerable<Product> SelectTopSellers()
        {
            return _cache.Retrieve<IEnumerable<Product>>("topSellers", () => _repository.SelectTopSellers());
        }
    }
}