using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAmenities()
        {
            var result = await _amenityService.GetAmenities();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAmenityById(int id)
        {
            var result = await _amenityService.GetAmenityById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAmenity(AmenityViewItem amenityViewItem)
        {
            var result = await _amenityService.CreateAmenity(amenityViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAmenity(AmenityViewItem amenityViewItem)
        {
            var result = await _amenityService.UpdateAmenity(amenityViewItem);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            var result = await _amenityService.DeleteAmenity(id);
            return Ok(result);
        }
    }
}