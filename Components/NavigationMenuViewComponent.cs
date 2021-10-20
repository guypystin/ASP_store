using ASP_store.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_store.Components
{
    // Компонента для вывода категорий
    public class NavigationMenuViewComponent : ViewComponent
    {
        // Внедрение зависимостей
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }
        // Фильтрация с помощью LINQ
        public IViewComponentResult Invoke()
            
        {
            ViewBag.SelectetCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
