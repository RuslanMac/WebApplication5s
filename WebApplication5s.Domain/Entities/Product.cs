using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Domain.Models
{
    public class Product
    {
        public Product()
        {

        }
        public long Id { get; private set; } 
        public string Name { get; private set; }
        public string Description { get; private  set; }

        public decimal Price { get; private set; }

        public List<ProductImage> Images { get; private set; } = new List<ProductImage>();

        public Category Category { get; private set; } 

        public long CategoryId { get; private set; }

        public Dictionary<string, string> Parameters { get; private set; } = new Dictionary<string, string>();

        public Product(string name, string description, decimal price, long categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        public void AddImage(ProductImage image)

        {
            Images.Add(image); 
        }




    }
}
