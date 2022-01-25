using Apartment.Business.Interfaces;
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
        public IActionResult GetApartments()
        {
            return Ok(_apartmentService.GetApartments());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetApartmentById(int id)
        {
            return Ok(_apartmentService.GetApartmentById(id));
        }
    }
}