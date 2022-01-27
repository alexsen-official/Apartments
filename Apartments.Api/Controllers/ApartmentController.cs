using System.Threading.Tasks;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetApartments()
        {
            var result = await _apartmentService.GetApartments();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetApartmentById(int id)
        {
            var result = await _apartmentService.GetApartmentById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateApartment(ApartmentViewModel apartmentViewModel)
        {
            var result = await _apartmentService.CreateApartment(apartmentViewModel);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateApartment(ApartmentViewModel apartmentViewModel)
        {
            var result = await _apartmentService.UpdateApartment(apartmentViewModel);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            var result = await _apartmentService.DeleteApartment(id);
            return Ok(result);
        }
    }
}