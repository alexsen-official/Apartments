using EFData;
using Apartment.Business.Services;
using Apartments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ApartmentController : Controller
    {
        private readonly EFApartmentsContext _context;

        public ApartmentController(EFApartmentsContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ApartmentViewModel GetApartmentById(int id)
        {
            ApartmentService apartmentService = new(_context);
            return apartmentService.GetApartmentById(id);
        }
    }
}