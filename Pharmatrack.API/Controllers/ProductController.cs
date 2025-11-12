using Microsoft.AspNetCore.Mvc;
using Pharmatrack.API.Services;
using Pharmatrack.ViewModels.Products;

namespace Pharmatrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _productService.GetAllProducts();
        if (!response.Success)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var response = _productService.GetProductById(id);
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _productService.CreateProduct(request);
        if (!response.Success)
            return BadRequest(response);

        return CreatedAtAction(nameof(GetById), new { id = response.Data?.Id }, response);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ProductRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = _productService.UpdateProduct(id, request);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var response = _productService.DeleteProduct(id);
        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }
}
