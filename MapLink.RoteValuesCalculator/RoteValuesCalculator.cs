using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.RoteValuesCalculator
{
    public class RoteValuesCalculator : IRoteValuesCalculator
    {
        public List<Address> Addresses = new List<Address>();

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
