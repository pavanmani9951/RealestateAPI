using System.ComponentModel.DataAnnotations;

namespace RealEstateAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "name can't be null")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "ImageUrl can't be null")]
        public string? ImageUrl { get; set; }

        public ICollection<Property> Properties { get; set;}
        // the above line code mentions the one to many relationship with the property class(table) 
    }
}
