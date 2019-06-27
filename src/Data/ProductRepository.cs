using Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;


        public ProductRepository(List<Product> products)
        {
            _products = products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }


    }
}
