using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_store.Models;
using ASP_store.Models.ViewModels;

namespace ASP_store.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository; //когда потребуется реализация интерфейса в startup прописано, что делать
        public int PageSize = 4;

        public ProductController(IProductRepository repo) //реализация внедрения завиимостей, глава 18
        {
            repository = repo;
        }

        public ViewResult List(int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }

            });
    }
                
}
