using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace testpr.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }    
    }
}
