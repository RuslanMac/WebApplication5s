using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WebApplication5s.Domain.Models
{
    public class Category
    {
        private Category()
        {

        }

        [Key]
        public long Id { get; private set; }
        public string Name { get; private set; }
        [JsonExtensionData]
        public List<string> Parameters { get; private set; } = new List<string>();
        [JsonConstructor] 
        public Category(string name)
        {
            Name = name; 
        }

        public void AddParameter(string parameter)
        {
            Parameters.Add(parameter); 
        }

     
    }

    public class CategoryParameters
    {
        public CategoryParameters()
        {

        }
        public List<string> Parameters { get; private set; }
    }
}
