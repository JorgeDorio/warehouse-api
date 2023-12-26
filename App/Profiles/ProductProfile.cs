using AutoMapper;
using Warehouse.Dtos.Product;
using Warehouse.Models;

namespace Warehouse.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();
    }
}