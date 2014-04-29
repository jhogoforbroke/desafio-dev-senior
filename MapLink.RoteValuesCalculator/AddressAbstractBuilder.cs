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
        protected IAddressService _addressService;

        protected Address address;
        
        public Address Address
        {
            get { return address; }
        }

        public AddressAbstractBuilder() {}

        protected AddressAbstractBuilder(string street, string number, string city, string state, IAddressService addressService)
        {
           address = BuildAddress(street, number, city, state, addressService);
        }

        public virtual Address BuildAddress(string street, string number, string city, string state, IAddressService addressService)
        {
            /* Singleton - Possibilita que um mesmo builder(AddressBuilder) 
               crie N products(Address) injetando a mesma instância de service(AddressService) */
            if (_addressService == null || !_addressService.GetType().Equals(addressService.GetType()))
                _addressService = addressService;

            address = new Address(_addressService);

            BuildAddressOptions();
            BuildProperties(street, number, city, state);

            return address;
        }
        protected abstract void BuildProperties(string street, string number, string city, string state);
        protected abstract void BuildAddressOptions();
    }
}
