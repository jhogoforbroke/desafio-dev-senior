using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class AddressBuilder : AddressAbstractBuilder
    {
        public AddressBuilder(string street, string number, string city, string state)
            : base(street, number, city, state)
        {
        }

        //TODO: Alterar para injeção da dependencia no builder para criação de um Address com service mock para testes unitários
        protected override AddressService BuildAddressService()
        {
            throw new System.NotImplementedException();
        }

        protected override void BuildProperties(string street, string number, string city, string state)
        {
            address.SetAddress(street, number, city, state); 
        }

        protected override void BuildAddressOptions()
        {
            address.AddressOptions = new AddressOptions
            {
                usePhonetic = true,
                searchType = Config.AddressSearchType,
                resultRange = BuildResultRange()
            };
        }

        private ResultRange BuildResultRange()
        {
            return new ResultRange
            {
                pageIndex = Config.AddressResultRangePageIndex,
                recordsPerPage = Config.AddressResultRecordsPerPage
            };
        }
    }
}
