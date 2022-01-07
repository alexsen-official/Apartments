using Apartments.Data;
using Apartment.Business.Services;
using Apartments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ApartmentController : Controller
    {
        private readonly ApartmentsDbContext _dbContext;

        public ApartmentController(ApartmentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet("{id}")]
        public ApartmentViewModel? GetApartmentById(int id)
        {
            ApartmentService apartmentService = new(_dbContext);
            return apartmentService.GetApartmentById(id);
        }
    }
}