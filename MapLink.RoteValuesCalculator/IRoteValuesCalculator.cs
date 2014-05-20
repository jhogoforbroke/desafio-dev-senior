using System.Collections.Generic;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public interface IRoteValuesCalculator
    {
        RouteCost Calculate();
        RouteCost Calculate(RouteType roteType);
    }
}
