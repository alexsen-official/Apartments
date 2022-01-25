using Apartment.Business.Interfaces;
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
    }
}