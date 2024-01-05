using AutoMapper;
using Warehouse.Dtos.Address;
using Warehouse.Models;

namespace Warehouse.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
    }
}