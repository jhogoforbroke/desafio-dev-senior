using System.Collections.Generic;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public interface IRoteValuesCalculator
    {
        RouteCost Calculate(List<Address> addresses);
        RouteCost Calculate(List<Address> addresses, RoteType roteType);
    }
}
