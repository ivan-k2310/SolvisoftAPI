using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolvisoftAPI.Data;
using System.Net.Http;

namespace SolvisoftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockWebshopController : ControllerBase

    {
        private readonly ILogger<MockWebshopController> _logger;
        public MockWebshopController( ILogger<MockWebshopController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ReceiveProducts([FromBody] List<Product> products)
        {
            _logger.LogInformation("Products recieved");
            return Ok(new { message = "Products received", count = products.Count });
        }
    }
}
