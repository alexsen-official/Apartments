using System.Collections.Generic;
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
        public IActionResult GetApartments()
        {
            IEnumerable<ApartmentViewModel> result = _apartmentService.GetApartments();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetApartmentById(int id)
        {
            ApartmentViewModel result = _apartmentService.GetApartmentById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateApartment(ApartmentViewModel apartmentViewModel)
        {
            IEnumerable<ApartmentViewModel> result = _apartmentService.CreateApartment(apartmentViewModel);
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult UpdateApartment(ApartmentViewModel apartmentViewModel)
        {
            IEnumerable<ApartmentViewModel> result = _apartmentService.UpdateApartment(apartmentViewModel);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteApartment(int id)
        {
            IEnumerable<ApartmentViewModel> result = _apartmentService.DeleteApartment(id);
            return Ok(result);
        }
    }
}