using Apartment.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]"), ApiController]
    public class AmenityController : Controller
    {
        private readonly IAmenityService _amenityService;

        public AmenityController(IAmenityService amenityService)
        {
            _amenityService = amenityService;
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            return Ok(_amenityService.GetAmenities());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetApartmentById(int id)
        {
            return Ok(_amenityService.GetAmenityById(id));
        }
    }
}