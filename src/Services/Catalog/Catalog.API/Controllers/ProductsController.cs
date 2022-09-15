using Microsoft.AspNetCore.Mvc;
using Catalog.API.Models.Entities;
using Catalog.API.Repositories.Interfaces;
using Catalog.API.Models.Requests;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByName([FromQuery] string name)
        {
            var products = await _productRepository.GetProductsByName(name);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _productRepository.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("Categories/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            var products = await _productRepository.GetProductsByCategory(category);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProduct createProduct)
        {
            var product = createProduct.ToProductModel();
            await _productRepository.CreateProduct(product);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] Product product)
        {
            var result = await _productRepository.UpdateProduct(product);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct(string id)
        {
            var result = await _productRepository.DeleteProduct(id);
            return Ok(result);
        }
    }
}
