﻿namespace RealEstateAPI.Models
{
    public class User
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public ICollection<Property> Properties { get; set; }
        // the above line code mentions the one to many relationship with the property class(table) 

    }
}
