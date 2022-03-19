using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task<Product> DeleteProduct (int id);
    }
}
