using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class AddressService
    {
        private readonly AddressFinder _addressFinder;

        public string Token = Config.AccessToken; // "c13iyCvmcC9mzwkLd0LCbmYC5mUF5m2jNGNtNGt6NmK6NJK=";

        public AddressService(AddressFinder addressFinder)
        {
            _addressFinder = addressFinder;
        }

        public Point FindPoint(Address address)
        {
            var findResponse = _addressFinder.findAddress(address.ToMapLinkAddress(), address.AddressOptions, Token);

            return (findResponse.addressLocation != null && findResponse.addressLocation.Length > 0) 
                ? findResponse.addressLocation[0].point : null;
        }
    }
}
