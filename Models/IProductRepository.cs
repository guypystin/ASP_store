using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_store.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; } //извлечение данных из product
    }
}
