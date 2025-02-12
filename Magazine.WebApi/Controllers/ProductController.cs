using Microsoft.AspNetCore.Mvc;
using Magazine.Core.Models;
using Magazine.Core.Services;
using System;
using System.Collections.Generic;

namespace Magazine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // 1?? Получить все товары
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        // 2?? Получить товар по ID
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(Guid id)
        {
            var product = _productService.Search(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // 3?? Добавить новый товар
        [HttpPost]
        public ActionResult<Product> Add(Product product)
        {
            var createdProduct = _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        // 4?? Удалить товар по ID
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(Guid id)
        {
            var deletedProduct = _productService.Remove(id);
            if (deletedProduct == null) return NotFound();
            return Ok(deletedProduct);
        }
    }
}
