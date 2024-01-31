using System.ComponentModel.DataAnnotations;

namespace RealEstateAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "name can't be null")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "name can't be null")]
        public string? ImageUrl { get; set; }
    }
}
