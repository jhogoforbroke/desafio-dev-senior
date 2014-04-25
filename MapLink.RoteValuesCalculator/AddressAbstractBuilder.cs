using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public abstract class AddressAbstractBuilder
    {
        protected Address address;

        public Address Address
        {
            get { return address; }
        }

        protected AddressAbstractBuilder(string street, string number, string city, string state)
        {
            address = new Address(BuildAddressService());
            BuildProperties(street, number, city, state);
        }

        protected abstract AddressService BuildAddressService();
        protected abstract void BuildProperties(string street, string number, string city, string state);
        protected abstract void BuildAddressOptions();
    }
}
