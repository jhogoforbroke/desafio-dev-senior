using System;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class RouteQueryResult
    {
        public DateTime TotalTimeRote { get; set; }
        public Decimal TotalDistance { get; set; }
        public Decimal TotalFuelCost { get; set; }
        public Decimal TotalCostWithToll { get; set; }

        
    }
}