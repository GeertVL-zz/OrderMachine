using System.Collections.Generic;

namespace OrderMachine
{
    public interface IProductRepository
    {
        IEnumerable<Product> SelectTopSellers();
    }
}