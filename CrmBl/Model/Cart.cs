using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CrmBl.Model
{
    public class Cart : IEnumerable
    {
        public Customer Customer { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public decimal Price => GetAll().Sum(p => p.Price);

        public Cart(Customer customer)
        {
            Customer = customer;
            Products = new Dictionary<Product, int>();
        }

        public void Add(Product product)
        {
            if(Products.TryGetValue(product, out int count))
            {
                Products[product] = ++count;
            }
            else
            {
                Products.Add(product, 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var product in Products.Keys)
            {
                for(int i = 0; i < Products[product]; i++)
                {
                    yield return product;
                }
            }
        }

        public List<Product> GetAll()
        {
            var result = new List<Product>();
            foreach(Product i in this)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
