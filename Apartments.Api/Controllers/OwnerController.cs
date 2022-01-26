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
        public IActionResult GetOwners()
        {
            return Ok(_ownerService.GetOwners());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOwnerById(int id)
        {
            return Ok(_ownerService.GetOwnerById(id));
        }
        
        [HttpPost]
        public IActionResult CreateOwner(OwnerViewItem ownerViewItem)
        {
            return Ok(_ownerService.CreateOwner(ownerViewItem));
        }
        
        [HttpPut]
        public IActionResult UpdateOwner(OwnerViewItem ownerViewItem)
        {
            return Ok(_ownerService.UpdateOwner(ownerViewItem));
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOwner(int id)
        {
            return Ok(_ownerService.DeleteOwner(id));
        }
    }
}