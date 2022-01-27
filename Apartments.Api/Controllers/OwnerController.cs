using System.Threading.Tasks;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]"), ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            var result = await _ownerService.GetOwners();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            var result = await _ownerService.GetOwnerById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOwner(OwnerViewItem ownerViewItem)
        {
            var result = await _ownerService.CreateOwner(ownerViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateOwner(OwnerViewItem ownerViewItem)
        {
            var result = await _ownerService.UpdateOwner(ownerViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var result = await _ownerService.DeleteOwner(id);
            return Ok(result);
        }
    }
}