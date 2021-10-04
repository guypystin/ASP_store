using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_store.Models
{
    //временное хранилище для продуктов, пока нет БД.
    public class FakeProductRepository : IProductRepository // Этот класс реалзует интерфейс IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Football", Price = 25},
            new Product {Name = "Football", Price = 25},
            new Product {Name = "Football", Price = 25}
        }.AsQueryable<Product>(); //преобразует коллекцию в IQueryable<Product> чтобы содать совместимое хранилище
    }
}
