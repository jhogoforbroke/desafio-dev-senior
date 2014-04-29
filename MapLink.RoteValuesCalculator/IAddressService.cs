using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public interface IAddressService
    {
        Point FindPoint(br.com.maplink.services.Address address, AddressOptions addressOptions);
    }
}
