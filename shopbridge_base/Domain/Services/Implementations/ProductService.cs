using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;

        private readonly IRepository<Product> repository;
        public ProductService(IRepository<Product> _repository)
        {
            this.repository = _repository;
        }

        async Task<IEnumerable<Product>> IProductService.GetAllProducts()
        {
            IEnumerable<Product> products = null;
            try
            {
                 products=await Task.FromResult(repository.Get());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = null;
            try
            {
                product = await Task.FromResult(repository.GetById(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return product;

        }

        public async Task<Product> AddProduct(Product product)
        {
            Product inserted = null;
            try
            {
                inserted = await Task.FromResult(repository.Insert(product));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return inserted;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            Product updated = null;
            try
            {
                product.Id = id;
                updated = await Task.FromResult(repository.Update(id,product));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return updated;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            Product deleted = null;
            try
            {
                deleted = await Task.FromResult(repository.Delete(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return deleted;
        }
    }
}
