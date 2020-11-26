using AutoMapper;
using DBCourseWorkBack.Api.DTOs;
using DBCourseWorkBack.BusinessLogic.Abstractions;
using DBCourseWorkBack.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync(ProductCreateDTO productDto)
        {
            var newProduct = _mapper.Map<Product>(productDto);
            var createdProduct = await _productService.AddProductAsync(newProduct);
            return Ok(createdProduct);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductAsync(Product productToUpdate)
        {
            var updatedProduct = await _productService.UpdateProductByIdAsync(productToUpdate);
            return Ok(updatedProduct);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductByIdAsync(id);
            return Ok();
        }
    }
}
