using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public abstract class AddressAbstractBuilder
    {
        protected IAddressService AddressService;

        protected Address address;
        
        public Address Address
        {
            get { return address; }
        }

        public AddressAbstractBuilder() {}

        protected AddressAbstractBuilder(string street, string number, string city, string state)
        {
           /* Criação do serviço deve ficar em um container de DI
              mas para fins de simplicidade e exemplo será realizado no proprio builder */
           var addressFinder = new AddressFinder();
           var addressService = new AddressService(addressFinder);
           address = BuildAddress(street, number, city, state, addressService);
        }

        public virtual Address BuildAddress(string street, string number, string city, string state, IAddressService addressService)
        {
            /* Singleton - Possibilita que um mesmo builder(AddressBuilder) 
               crie N products(Address) injetando a mesma instância de service(AddressService) */
            if (AddressService == null || !(AddressService.GetType() == addressService.GetType()))
                AddressService = addressService;

            address = new Address(AddressService);

            BuildAddressOptions();
            BuildProperties(street, number, city, state);

            return address;
        }
        protected abstract void BuildProperties(string street, string number, string city, string state);
        protected abstract void BuildAddressOptions();
    }
}
