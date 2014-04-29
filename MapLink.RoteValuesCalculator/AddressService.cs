using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class AddressService : IAddressService
    {
        private readonly AddressFinder _addressFinder;

        private readonly string Token = Config.AccessToken;

        public AddressService(AddressFinder addressFinder)
        {
            _addressFinder = addressFinder;
        }

        public Point FindPoint(br.com.maplink.services.Address address, AddressOptions addressOptions)
        {
            var findResponse = _addressFinder.findAddress(address, addressOptions, Token);

            return (findResponse.addressLocation != null && findResponse.addressLocation.Length > 0) 
                ? findResponse.addressLocation[0].point : null;
        }
    }
}
