using System.Collections.Generic;
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
            IEnumerable<AmenityViewItem> result = _amenityService.GetAmenities();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAmenityById(int id)
        {
            AmenityViewItem result = _amenityService.GetAmenityById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateAmenity(AmenityViewItem amenityViewItem)
        {
            IEnumerable<AmenityViewItem> result = _amenityService.CreateAmenity(amenityViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult UpdateAmenity(AmenityViewItem amenityViewItem)
        {
            IEnumerable<AmenityViewItem> result = _amenityService.UpdateAmenity(amenityViewItem);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAmenity(int id)
        {
            IEnumerable<AmenityViewItem> result = _amenityService.DeleteAmenity(id);
            return Ok(result);
        }
    }
}