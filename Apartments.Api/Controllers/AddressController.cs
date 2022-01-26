using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
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
        public IActionResult GetAddressesById(int id)
        {
            return Ok(_addressService.GetAddressById(id));
        }
        
        [HttpPost]
        public IActionResult CreateAddress(AddressViewItem addressViewItem)
        {
            return Ok(_addressService.CreateAddress(addressViewItem));
        }
        
        [HttpPut]
        public IActionResult UpdateAddress(AddressViewItem addressViewItem)
        {
            return Ok(_addressService.UpdateAddress(addressViewItem));
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAddress(int id)
        {
            return Ok(_addressService.DeleteAddress(id));
        }
    }
}