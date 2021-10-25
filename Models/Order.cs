using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_store.Models
{
    
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите первую строку адресса")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите город")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите название страны")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
