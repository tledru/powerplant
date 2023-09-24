using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using PowerPlant.Domain;
using PowerPlant.Host.Requests;

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

        [HttpPost(Name = "ComputeProductionPlan")]
        public IActionResult Post(ComputeProductionPlanRequest request)
        {
            try
            {

                Guard.Against.Null(request.Fuels, nameof(request.Fuels));
                Guard.Against.Null(request.PowerPlants, nameof(request.PowerPlants));

                ProductionPlan plan = new();
                var context = new Domain.FuelContext(request.Fuels.GasPrice, request.Fuels.KerosinePrice, request.Fuels.Co2Price, request.Fuels.WindStrength);

                foreach (var item in request.PowerPlants)
                {
                    Guard.Against.NullOrWhiteSpace(item.Name, nameof(item.Name));
                    Guard.Against.NullOrWhiteSpace(item.Type, nameof(item.Type));

                    var efficiency = new Efficiency(item.Efficiency);
                    var boundaries = new PowerRange(item.Pmin, item.Pmax);
                    var powerPlant = Domain.PowerPlant.Create(item.Name, efficiency, boundaries, item.Type, context);
                    plan.Add(powerPlant);
                }

                var result = plan.Compute(request.Load).ToArray();
                return Ok(result);
            }
            catch (BusinessException e)
            {
                _logger.LogError(e, "Body received : {@request}", request);
                return BadRequest(new {error = e.Message});
            }
        }
    }
}