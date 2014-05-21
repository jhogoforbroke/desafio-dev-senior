using MapLink.RoteValuesCalculator.br.com.maplink.services;

namespace MapLink.RoteValuesCalculator
{
    public interface IAddressService
    {
        Point FindPoint(br.com.maplink.services.Address address, AddressOptions addressOptions);
    }
}
