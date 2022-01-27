using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAddresses()
        {
            var result = await _addressService.GetAddresses();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAddressesById(int id)
        {
            var result = await _addressService.GetAddressById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAddress(AddressViewItem addressViewItem)
        {
            var result = await _addressService.CreateAddress(addressViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(AddressViewItem addressViewItem)
        {
            var result = await _addressService.UpdateAddress(addressViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = await _addressService.DeleteAddress(id);
            return Ok(result);
        }
    }
}