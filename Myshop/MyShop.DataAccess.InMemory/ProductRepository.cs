using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public List<Product> Products { get => products; set => products = value; }

        public ProductRepository()
        {
            Products = cache["products"] as List<Product>;
            if (Products == null)
            {
                Products = new List<Product>();
            }
        }

        public List<Product> CollectionsToList()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            cache["products"] = Products;
        }

        public void Insert(Product p)
        {
            Products.Add(p);
        }

        public void Update(Product product)
        {
            Product productToUpdate = Products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public Product Find(string Id)
        {
            Product productFind = Products.Find(p => p.Id == Id);
            if (productFind != null)
            {
                return productFind;
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }

        public IQueryable<Product> Collection()
        {
            return Products.AsQueryable();
        }

        public void Delete(string Id)
        {
            Product productToDelete = Products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }
    }
}