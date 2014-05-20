using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.RoteValuesCalculator
{
    public class RoteValuesCalculator : IRoteValuesCalculator
    {
        public List<Address> Addresses { get; set; }

        public RouteCost Calculate()
        {
            throw new NotImplementedException();
        }

        public RouteCost Calculate(RoteType roteType)
        {
            throw new NotImplementedException();
        }
    }
}
