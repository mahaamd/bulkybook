using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace testpr.Models
{
    public class Product
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]   
        public string Name { get; set; }
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int ISBN { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Author { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Range(1, 10000)]

        public double Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Range(1, 10000)]

        public double price50 { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Range(1, 10000)]
        public double price100 { get; set; }
        public string ImageUrl { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required]
        public int CategoryId { get; set; }
        public Category category;

        [System.ComponentModel.DataAnnotations.Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }
    }
}
