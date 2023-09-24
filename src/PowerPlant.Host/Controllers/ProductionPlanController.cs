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
        public IEnumerable<PowerPlantProduction> Post(ComputeProductionPlanRequest request)
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

            return plan.Compute(request.Load);
        }
    }
}