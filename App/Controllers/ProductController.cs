using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Dtos.Product;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ProductService productService, IMapper mapper)
{
    private readonly ProductService _productService = productService;
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task Create([FromBody] CreateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productService.Create(product);
    }

    [HttpGet]
    public IEnumerable<Product> ReadAll()
    {
        var result = _productService.ReadAll();
        return result;
    }

    [HttpDelete]
    public async Task Delete([FromQuery] int id)
    {
        await _productService.Delete(id);
    }

    [HttpPut]
    public async Task Update([FromBody] UpdateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productService.Update(product);
    }
}