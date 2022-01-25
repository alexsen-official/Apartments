using Apartment.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]"), ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            return Ok(_addressService.GetAddresses());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetApartmentById(int id)
        {
            return Ok(_addressService.GetAddressById(id));
        }
    }
}