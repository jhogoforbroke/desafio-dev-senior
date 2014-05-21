using MapLink.RoteValuesCalculator.RouteService;
using System.Collections.Generic;
using NUnit.Framework;

namespace MapLink.RoteValuesCalculator.Test
{
    /* * * * *
     * 
     * Should enter with a address list (state, street, city, number)
     * and return a cost of route (total time, distance, fuel cost, cost with toll)
     * 
     * */

    [TestFixture]
    public class RoutevaluesCalculatorTest
    {
        private RoteValuesCalculator _calculator;

        private readonly List<Address> _addressList = new List<Address>();
        private AddressBuilder _addressBuilder;

        [SetUp]
        public void SetUp()
        {
            _addressBuilder = new AddressBuilder();

            var vehicle = new Vehicle { tankCapacity = 20, averageConsumption = 9, fuelPrice = 3, averageSpeed = 60 };

            _calculator = new RoteValuesCalculator(vehicle);
        }

        [Test]
        public void Should_calcule_total_value_rote()
        {
            _addressList.Add(new AddressBuilder("Av. Paulista", "200", "São Paulo", "São Paulo").Address);
            _addressList.Add(new AddressBuilder("Rua Funchal", "9.699", "São Paulo", "São Paulo").Address);
            _calculator.Addresses = _addressList;

            var totalCost = _calculator.Calculate();

            Assert.NotNull(totalCost);

            Assert.NotNull(totalCost.TotalDistance);
            Assert.NotNull(totalCost.TotalCostWithToll);
            Assert.NotNull(totalCost.TotalFuelCost);
            Assert.NotNull(totalCost.TotalTimeRote);
        }

        [Test]
        public void Should_calcule_total_value_rote_avoidingTraffic()
        {
            _addressList.Add(new AddressBuilder("Av. Paulista", "200", "São Paulo", "São Paulo").Address);
            _addressList.Add(new AddressBuilder("Rua Funchal", "9.699", "São Paulo", "São Paulo").Address);
            _calculator.Addresses = _addressList;

            var totalCost = _calculator.Calculate(RouteType.AvoidingTraffic);

            Assert.NotNull(totalCost);

            Assert.NotNull(totalCost.TotalDistance);
            Assert.NotNull(totalCost.TotalCostWithToll);
            Assert.NotNull(totalCost.TotalFuelCost);
            Assert.NotNull(totalCost.TotalTimeRote);
        }

        [Test]
        public void Should_find_a_address_point()
        {
            var address = new AddressBuilder("Av. Paulista", "200", "São Paulo", "São Paulo").Address;

            Assert.IsNotNull(address.Point);
        }
    }
}
