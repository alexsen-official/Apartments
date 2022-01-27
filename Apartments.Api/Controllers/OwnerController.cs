using System.Collections.Generic;
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
            IEnumerable<OwnerViewItem> result = _ownerService.GetOwners();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOwnerById(int id)
        {
            OwnerViewItem result = _ownerService.GetOwnerById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateOwner(OwnerViewItem ownerViewItem)
        {
            IEnumerable<OwnerViewItem> result = _ownerService.CreateOwner(ownerViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult UpdateOwner(OwnerViewItem ownerViewItem)
        {
            IEnumerable<OwnerViewItem> result = _ownerService.UpdateOwner(ownerViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOwner(int id)
        {
            IEnumerable<OwnerViewItem> result = _ownerService.DeleteOwner(id);
            return Ok(result);
        }
    }
}