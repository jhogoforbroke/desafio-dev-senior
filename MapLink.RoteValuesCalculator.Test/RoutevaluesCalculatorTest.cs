using MapLink.RoteValuesCalculator.br.com.maplink.services;
using NUnit.Framework;

namespace MapLink.RoteValuesCalculator.Test
{
    [TestFixture]
    public class RoutevaluesCalculatorTest
    {
        public void Should_find_a_address_point()
        {
            var address = new Address();
            var addressOptions = new AddressOptions();
            var addressFinder = new AddressFinder();

            var addressService = new AddressService(addressFinder);

            var point = addressService.FindPoint(address, addressOptions);


        }
    }

    public class AddressService
    {
        private readonly AddressFinder _addressFinder;

        public string Token = "";

        public AddressService(AddressFinder addressFinder)
        {
            _addressFinder = addressFinder;
        }

        public Point FindPoint(Address address, AddressOptions addressOptions)
        {
            var findResponse = _addressFinder.findAddress(address, addressOptions, Token);

            return (findResponse.addressLocation != null && findResponse.addressLocation.Length > 0) 
                ? findResponse.addressLocation[0].point : null;
        }
    }
}
