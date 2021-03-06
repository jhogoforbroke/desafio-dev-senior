﻿using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public class AddressBuilder : AddressAbstractBuilder
    {
        public AddressBuilder() {}

        public AddressBuilder(string street, string number, string city, string state)
            : base(street, number, city, state) {}

        
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
