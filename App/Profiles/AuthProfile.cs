using AutoMapper;
using Warehouse.Dtos.Auth;
using Warehouse.Models;

namespace Warehouse.Profiles;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<LoginDto, Customer>();
        CreateMap<RegisterDto, Customer>();
    }
}