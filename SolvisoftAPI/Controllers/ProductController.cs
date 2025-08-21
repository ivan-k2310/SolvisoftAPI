using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolvisoftAPI.Data;

namespace SolvisoftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductDbContext context, IHttpClientFactory httpClientFactory, ILogger<ProductController> logger)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet("FilteredProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts() 
        { 
            try
            {
                var products = await _context.Products
                    .Where(p => p.Stock > 0
                     && p.LastUpdated >= DateTime.UtcNow.AddDays(-30))
                    .ToListAsync();

                _logger.LogInformation("Succesfully send products");
                return Ok(products);
                
            } catch (Exception ex)
            {
                _logger.LogError( ex, "Failed to GET products");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("AllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();

                _logger.LogInformation("Succesfully send ALL products");
                return Ok(products);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to GET products");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("SendProducts")]
        public async Task<IActionResult> SendProductsToWebshop()
        {
            try
            {
                // Get All products
                var products = await _context.Products.ToListAsync();
                _logger.LogInformation("Retrieved {Count} products from database.", products.Count);
                

                var client = _httpClientFactory.CreateClient();

                // POST to mock end-point
                _logger.LogInformation("Sending Products to: https://localhost:7181/api/mockwebshop");
                var response = await client.PostAsJsonAsync("https://localhost:7181/api/mockwebshop", products);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Products successfully sent.");
                    return Ok(new { message = "Products sent successfully" });
                }
                else
                {
                    _logger.LogWarning("Failed to send products. StatusCode: {StatusCode}", response.StatusCode);
                    return StatusCode((int)response.StatusCode, "Failed to send products");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending products to webshop.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
