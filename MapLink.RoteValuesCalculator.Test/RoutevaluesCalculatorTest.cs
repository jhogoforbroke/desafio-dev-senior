using MapLink.RoteValuesCalculator.br.com.maplink.services;
using MapLink.RoteValuesCalculator.RouteService;
using Moq;
using System.Collections.Generic;
using NUnit;
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

        private List<Address> _addressList = new List<Address>();
        private AddressBuilder _addressBuilder = new AddressBuilder();

        private Mock<IAddressService> addressServiceMock = new Mock<IAddressService>();

        [SetUp]
        public void SetUp()
        {
            var vehicle = new Vehicle();
            vehicle.tankCapacity = 20;
            vehicle.averageConsumption = 9;
            vehicle.fuelPrice = 3;
            vehicle.averageSpeed = 60;

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
