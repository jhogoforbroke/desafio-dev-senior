﻿using System;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class RouteCost
    {
        public String TotalTimeRote { get; set; }
        public Double TotalDistance { get; set; }
        public Double TotalFuelCost { get; set; }
        public Double TotalCostWithToll { get; set; }
    }
}