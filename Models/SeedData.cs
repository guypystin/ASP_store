using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_store.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Лодка",
                        Description = "Лодка на одну персону",
                        Category = "Водный спорт",
                        Price = 3000,
                    },
                    new Product
                    {
                        Name = "Спасательный жилет",
                        Description = "Надежный желет для морских путешествий",
                        Category = "Водный спорт",
                        Price = 500,
                    },
                    new Product
                    {
                        Name = "Футбольный мяч",
                        Description = "Таким мячом играли на FIFA 2005",
                        Category = "Футбол",
                        Price = 2500,
                    },
                    new Product
                    {
                        Name = "Футбольный флажок",
                        Description = "Для пресечения нарушений в футболе",
                        Category = "Футбол",
                        Price = 400,
                    },
                    new Product
                    {
                        Name = "Стадион",
                        Description = "Игрушечный стадион",
                        Category = "Футбол",
                        Price = 15000,
                    },
                    new Product
                    {
                        Name = "Шахматная доска",
                        Description = "Хорошая доска для игры в шахматы",
                        Category = "Шахматы",
                        Price = 500,
                    },
                    new Product
                    {
                        Name = "Фигурки для шахмат",
                        Description = "Стильные фигурки для шахмат",
                        Category = "Шахматы",
                        Price = 1000,
                    }
                );
                context.SaveChanges();
            }
               
            
        }
    }
}
