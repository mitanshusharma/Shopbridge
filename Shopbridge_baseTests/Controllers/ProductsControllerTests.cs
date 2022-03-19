using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopbridge_base.Controllers;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_baseTests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopbridge_base.Controllers.Tests
{   

    [TestClass()]
    public class ProductsControllerTests
    {
        private readonly ProductsController _controller;
        private readonly IProductService _productService;

        public ProductsControllerTests()
        {
            _productService = new ProductServiceMock();
            _controller = new ProductsController(_productService);
        }

        [TestMethod()]
        public void GetProductsTest_ReturnsCorrectType()
        {
            var okResult = _controller.GetProduct();
            Assert.IsInstanceOfType(okResult,typeof(Task<ActionResult<IEnumerable<Product>>>));
        }
        
        [TestMethod()]
        public void GetProductsTest_ReturnsAllItems()
        {
            var result = (List<Product>)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.GetProduct().Result.Result).Value;
            Assert.AreEqual(2,result.Count);
        }

        [TestMethod()]
        public void GetProductTest()
        {
            var result = (Product)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.GetProduct(1).Result.Result).Value;
            Assert.AreEqual("Pencil", result.Name); 
        }

        [TestMethod()]
        public void PutProductTest()
        {
            var productToBeUpdated = (Product)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.GetProduct(2).Result.Result).Value;
            Product updatedProduct = new Product() { Id = 2, Name = "Eraser", Description = "Camel Eraser", Price = 100M };
            var result= (Product)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.PutProduct(2,updatedProduct).Result).Value;
            Assert.AreEqual(100M, result.Price);
        }

        [TestMethod()]
        public void PostProductTest()
        {
            Product product = new Product();
            product.Name = "Test";
            product.Description = "Test Description";
            product.Price = 200M;
            var result=(Product)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.PostProduct(product).Result.Result).Value;
            Assert.AreEqual("Test", result.Name);

        }

        [TestMethod()]
        public void DeleteProductTest()
        {
            var productToBeDeleted = (Product)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.GetProduct(2).Result.Result).Value;
            var deletedProduct=(Product)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.DeleteProduct(2).Result).Value;
            var result=  (Product)((Microsoft.AspNetCore.Mvc.ObjectResult)_controller.GetProduct(2).Result.Result).Value;
            Assert.IsNull(result);

        }
    }
}