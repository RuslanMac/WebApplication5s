using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication5s.Domain.Models
{
    public class ProductImage
    {
        public ProductImage()
        {

        } 
        public long Id { get; private set; } 
        public byte[] Image { get; private set; }   

        public Product Product { get; private set; }    

        public long ProductId { get; private set; } 

        public ProductImage(byte[] image, long productId)
        {
            Image = image;
            ProductId = productId;
        }
    }
}
