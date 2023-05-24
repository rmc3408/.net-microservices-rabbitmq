using catalog.API.Entities;
using catalog.API.BusinessServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace catalog.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductService _mongoServiceRepo;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductService productRepository, ILogger<CatalogController> logger)
        {
            _mongoServiceRepo = productRepository;
            _logger = logger;
        }

        // GET: /
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var listProduct = await _mongoServiceRepo.GetProducts();
            return listProduct == null ? NotFound() : Ok(listProduct);
        }

        // GET: /{id}
        [HttpGet("{id:length(24)}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _mongoServiceRepo.GetProductById(id);
            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(product);
        }

        // GET: GetCategory/{category}
        [Route("[action]/{category}", Name = "GetProductsByCategory")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetCategory(string category)
        {
            var products = await _mongoServiceRepo.GetProductsByCategory(category);
            return Ok(products);
        }

        // POST /
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<Product>))]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _mongoServiceRepo.CreateProduct(product);
            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
        }

        // PUT /
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result = await _mongoServiceRepo.UpdateProduct(product);
            return Ok(result);
        }

        // DELETE /{id}
        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            var result = await _mongoServiceRepo.DeleteProduct(id);
            return Ok(result);
        }
    }
}
