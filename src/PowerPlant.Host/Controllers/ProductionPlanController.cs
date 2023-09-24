using Microsoft.AspNetCore.Mvc;

namespace PowerPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;

        public ProductionPlanController(ILogger<ProductionPlanController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProductionPlan")]
        public string Get()
        {
            return "dummyValue";
        }
    }
}