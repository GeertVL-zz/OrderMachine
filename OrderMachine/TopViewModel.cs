using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderMachine
{
    public class TopViewModel
    {
        private readonly IProductRepository _repository;

        public TopViewModel(IProductRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        public IEnumerable<string> TopSellers
        {
            get
            {
                var topSellers = _repository.SelectTopSellers();
                return from p in topSellers select p.Name;
            }
        } 
    }
}