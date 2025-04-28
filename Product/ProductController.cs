using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{

  private readonly ProductService productService;

  public ProductController(ProductService productService)
  {
    this.productService = productService;
  }

  [HttpPost("create")]
  public IActionResult CreateProduct([FromBody] ProductDto dto)
  {
    try
    {
      Product product = productService.CreateProduct(dto.Name, dto.Price, dto.Amount, dto.Category);
      return Ok(new ProductDto(product));
    }
    catch (Exception)
    {
      return BadRequest();
    }
  }}