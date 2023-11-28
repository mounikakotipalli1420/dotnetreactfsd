using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Exceptions;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;
using ShoppingApp.Services;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService,ILogger<ProductController>logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.GetProducts();
                _logger.LogInformation("product listed");
                return Ok(result);
            }
            catch (NoProductsAvailableException e)
            {
                errorMessage = e.Message;
                _logger.LogError("No products are available in the list");
            }
            return BadRequest(errorMessage);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.Add(product);
                _logger.LogInformation($"Product created: {result}");
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                _logger.LogError($"Error: {e.Message}");
            }
            return BadRequest(errorMessage);
        }
    }
}
