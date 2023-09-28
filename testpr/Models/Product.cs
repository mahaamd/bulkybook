using MessagePack;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [ValidateNever]
        public string ImageUrl { get; set; }
        
        [System.ComponentModel.DataAnnotations.Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        [ValidateNever]
        public CoverType CoverType { get; set; }
    }
}
