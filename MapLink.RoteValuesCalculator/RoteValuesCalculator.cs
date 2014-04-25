using System.Collections.Generic;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public interface IRoteValuesCalculator
    {
        RouteQueryResult Calculate(List<Address> addresses, RoteType roteType);
    }
}
