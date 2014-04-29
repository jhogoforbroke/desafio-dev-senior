using MapLink.RoteValuesCalculator.br.com.maplink.services;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MapLink.RoteValuesCalculator.Test
{
    [TestClass()]
    public class RoutevaluesCalculatorTest
    {
        private IRoteValuesCalculator _calculator = new RoteValuesCalculator();

        private List<Address> _addressList = new List<Address>();
        private AddressBuilder _addressBuilder = new AddressBuilder();

        private Mock<IAddressService> addressServiceMock = new Mock<IAddressService>();

        public void Should_calcule_total_value_rote()
        {
            addressServiceMock.Setup(x => x.FindPoint(It.IsAny<br.com.maplink.services.Address>(), It.IsAny<AddressOptions>())).Returns(new Point());
            _addressList.Add(_addressBuilder.BuildAddress("RUA TESTE 1", "100", "São Paulo", "São Paulo", addressServiceMock.Object));

            addressServiceMock.Setup(x => x.FindPoint(It.IsAny<br.com.maplink.services.Address>(), It.IsAny<AddressOptions>())).Returns(new Point());
            _addressList.Add(_addressBuilder.BuildAddress("RUA TESTE 2", "200", "São Paulo", "São Paulo", addressServiceMock.Object));

            _calculator.Addresses = _addressList;
            var totalCost = _calculator.Calculate();
        }

        [TestMethod]
        public void Should_find_a_address_point()
        {
            var addressFinder = new AddressFinder();
            var addressService = new AddressService(addressFinder);

            var address = new AddressBuilder("Rua Funchal", "9.699", "São Paulo", "São Paulo", addressService).Address;

            Assert.IsNotNull(address.Point);
        }
    }

    

    

    
}
