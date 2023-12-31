using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Dtos.Auth;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(AuthService AuthService, IMapper mapper)
{
    private readonly AuthService _AuthService = AuthService;
    private readonly IMapper _mapper = mapper;

    [HttpPost("Register")]
    public async Task Register([FromBody] RegisterDto registerDto)
    {
        var customer = _mapper.Map<Customer>(registerDto);
        await _AuthService.Register(customer);
    }

    [HttpPost("Login")]
    public string Login([FromBody] LoginDto loginDto)
    {
        var customer = _mapper.Map<Customer>(loginDto);
        var result = _AuthService.Login(customer);
        return result;
    }
}