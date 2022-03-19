using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopbridge_baseTests.Services
{
    class ProductServiceMock : IProductService
    {

        private readonly List<Product> _products;

        public ProductServiceMock()
        {
            _products = new List<Product>()
            {
                new Product(){ Id=1,Name="Pencil",Description="HB Pencil",Price=10.12M},
                new Product(){ Id=2,Name="Eraser",Description="Camel Eraser",Price=20.00M}
            };
        }
        public Task<Product> AddProduct(Product product)
        {
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<Product> DeleteProduct(int id)
        {
            var product = _products.Find(x => x.Id == id);
            _products.Remove(product);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        public Task<Product> GetProduct(int id)
        {
            var product = _products.Find(x => x.Id == id);
            return Task.FromResult(product);
        }

        public Task<Product> UpdateProduct(int id, Product product)
        {
            var oldProduct = _products.Find(x => x.Id == id);
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.Price = product.Price;
            var result = _products.Find(x => x.Id == id);
            return Task.FromResult(result);
        }
    }
}
