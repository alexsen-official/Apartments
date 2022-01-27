using System.Collections.Generic;
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
            IEnumerable<AddressViewItem> result = _addressService.GetAddresses();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAddressesById(int id)
        {
            AddressViewItem result = _addressService.GetAddressById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateAddress(AddressViewItem addressViewItem)
        {
            IEnumerable<AddressViewItem> result = _addressService.CreateAddress(addressViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult UpdateAddress(AddressViewItem addressViewItem)
        {
            IEnumerable<AddressViewItem> result = _addressService.UpdateAddress(addressViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteAddress(int id)
        {
            IEnumerable<AddressViewItem> result = _addressService.DeleteAddress(id);
            return Ok(result);
        }
    }
}