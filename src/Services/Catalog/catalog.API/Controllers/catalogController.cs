using catalog.API.Entities;
using catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        // GET: api/<catalogController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var listProduct = await _productRepository.GetProducts();
            return listProduct;
        }

        // GET api/<catalogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<catalogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<catalogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<catalogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
