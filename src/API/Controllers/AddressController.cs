using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class AddressController : Controller
{
    private readonly IAddressService _addressService;
    
    // DI
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }
}