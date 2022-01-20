using Apartment.Business.Services.Interfaces;
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

        [HttpGet("{id}")]
        public IActionResult GetApartmentById(int id)
        {
            return Ok(_apartmentService.GetApartmentById(id));
        }
    }
}