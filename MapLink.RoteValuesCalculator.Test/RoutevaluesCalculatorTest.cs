using MapLink.RoteValuesCalculator.br.com.maplink.services;
using NUnit.Framework;
using System.Collections.Generic;

namespace MapLink.RoteValuesCalculator.Test
{
    [TestFixture]
    public class RoutevaluesCalculatorTest
    {
        private List<Address> _addressList;

        public void Should_calcule_total_value_rote()
        {
            _addressList.Add(new AddressBuilder("Av. Brigadeiro Faria Lima", "1.000", "São Paulo", "São Paulo").Address);
            _addressList.Add(new AddressBuilder("Av. Paulista", "200", "São Paulo", "São Paulo").Address);
            
        }

        [Test]
        public void Should_find_a_address_point()
        {
            var address = new AddressBuilder("Rua Funchal", "9.699", "São Paulo", "São Paulo").Address;
            var point = address.Point;


        }
    }

    

    

    
}
