using System.Collections.Generic;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public interface IRoteValuesCalculator
    {
        List<Address> Addresses;

        RouteCost Calculate();
        RouteCost Calculate(RoteType roteType);
    }
}
