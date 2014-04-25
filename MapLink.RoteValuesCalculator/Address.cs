using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class Address
    {
        public String State { get; private set; }
        public String City { get; private set; }
        public String Street { get; private set; }
        public String Number { get; private set; }

        public AddressOptions AddressOptions { get; set; }
        public Point Point { get; private set; }

        private AddressService _addressService;

        public Address(AddressService addressService)
        {
            _addressService = addressService;
        }

        // Garante a integridade do Point caso o endereço mude executando 
        // o metodo de busca(chamda ao WebService) somente uma vez 
        public void SetAddress(string street, string number, string city, string state)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;

            Point = FindPoint();
        }

        public Point FindPoint()
        {
            return _addressService.FindPoint(this);
        }

        public br.com.maplink.services.Address ToMapLinkAddress()
        {
            var city = new br.com.maplink.services.City
            {
                name = City,
                state = State
            };

            return new br.com.maplink.services.Address
            {
                city = city,
                street = Street,
                houseNumber = Number
            };
        }

        public override string ToString()
        {
            return String.Format("{0}, {1} - {2}/{3}", Street, Number, City, State);
        }
    }
}
