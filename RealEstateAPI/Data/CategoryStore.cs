using RealEstateAPI.Models;

namespace RealEstateAPI.Data
{
    public static class CategoryStore
    {
        public static List<Category> categories = new List<Category>
        {
            new Category{Id=1,Name="ChennaiVillaas",ImageUrl=""},
            new Category{Id=2,Name="MumbaiVillas",ImageUrl=""},
            new Category{Id=3,Name="PondiVillas",ImageUrl=""}
         }; 
    }
}
