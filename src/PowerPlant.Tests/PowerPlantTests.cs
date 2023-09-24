using FluentAssertions;
using PowerPlant.Domain;

namespace PowerPlant.Tests
{
    public class PowerPlantTests
    {
        [Fact]
        public void WhenPowerPlantTypeIsUnknownShouldThrow()
        {
            string name = "outofthisworld";
            Domain.Efficiency efficiency = new(0.5f);
            Domain.PowerRange boundaries = new(0, 100);
            string type = "unknown";
            Domain.FuelContext context = new(12.5f, 15.2f, 20f, 60f);

            var action = () => Domain.PowerPlant.Create(name, efficiency, boundaries, type, context);

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void WhenPowerPlantTypeIsKnownShouldReturnProperType()
        {
            string name = "outofthisworld";
            Efficiency efficiency = new(0.5f);
            PowerRange boundaries = new(0, 100);
            FuelContext context = new(12.5f, 15.2f, 20f, 60f);

            var windturbine = Domain.PowerPlant.Create(name, efficiency, boundaries, "windturbine", context);
            var gasfired = Domain.PowerPlant.Create(name, efficiency, boundaries, "gasfired", context);
            var turbojet = Domain.PowerPlant.Create(name, efficiency, boundaries, "turbojet", context);

            windturbine.Should().BeOfType<WindTurbinePowerPlant>();
            gasfired.Should().BeOfType<GasFiredPowerPlant>();
            turbojet.Should().BeOfType<TurboJetPowerPlant>();
        }

        [Theory]
        [InlineData(0,100,100,15,100)]
        [InlineData(0,90,100,15,85)]
        public void WhenComputingProductionShouldReturnExpectedLoad(int minimum, int maximum, float load, int minimumRemainingIfNotZero, float expected)
        {
            string name = "outofthisworld";
            Efficiency efficiency = new(0.5f);
            PowerRange boundaries = new(minimum, maximum);
            FuelContext context = new(12.5f, 15.2f, 20f, 60f);

            var gasfired = Domain.PowerPlant.Create(name, efficiency, boundaries, "gasfired", context);

            var powerPlantProduction = gasfired.ComputeProduction(load, minimumRemainingIfNotZero);

            powerPlantProduction.Production.Should().Be(expected);
        }
    }
}