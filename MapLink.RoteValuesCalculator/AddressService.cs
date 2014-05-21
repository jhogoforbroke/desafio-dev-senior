using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class AddressService : IAddressService
    {
        private readonly AddressFinder _addressFinder;

        private readonly string _token = Config.AccessToken;

        public AddressService(AddressFinder addressFinder)
        {
            _addressFinder = addressFinder;
        }

        public Point FindPoint(br.com.maplink.services.Address address, AddressOptions addressOptions)
        {
            var findResponse = _addressFinder.findAddress(address, addressOptions, _token);

            return (findResponse.addressLocation != null && findResponse.addressLocation.Length > 0) 
                ? findResponse.addressLocation[0].point : null;
        }
    }
}
