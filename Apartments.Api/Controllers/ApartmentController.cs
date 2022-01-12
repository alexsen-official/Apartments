using Apartment.Business.Services;
using Apartments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Apartments.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ApartmentController : Controller
    {
        private readonly IConfiguration _config;

        public ApartmentController(IConfiguration config)
        {
            _config = config;
        }
        
        [HttpGet("{id}")]
        public ApartmentViewModel GetApartmentById(int id)
        {
            ApartmentService apartmentService = new(_config);
            return apartmentService.GetApartmentById(id);
        }
    }
}