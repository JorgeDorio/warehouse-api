using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Dtos.Address;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController(AddressService AddressService, IMapper mapper)
{
    private readonly AddressService _addressService = AddressService;
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task Create([FromBody] CreateAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);
        await _addressService.Create(address);
    }

    [HttpGet]
    public IEnumerable<Address> ReadByCustomerId([FromQuery] int id)
    {
        var result = _addressService.ReadByCustomerId(id);
        return result;
    }
}