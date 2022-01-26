using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
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
        public IActionResult GetAmenities()
        {
            return Ok(_amenityService.GetAmenities());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAmenityById(int id)
        {
            return Ok(_amenityService.GetAmenityById(id));
        }
        
        [HttpPost]
        public IActionResult CreateAmenity(AmenityViewItem amenityViewItem)
        {
            return Ok(_amenityService.CreateAmenity(amenityViewItem));
        }
        
        [HttpPut]
        public IActionResult UpdateAmenity(AmenityViewItem amenityViewItem)
        {
            return Ok(_amenityService.UpdateAmenity(amenityViewItem));
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAmenity(int id)
        {
            return Ok(_amenityService.DeleteAmenity(id));
        }
    }
}