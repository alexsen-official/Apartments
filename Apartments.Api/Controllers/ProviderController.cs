using Apartment.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]"), ApiController]
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            return Ok(_providerService.GetProviders());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProviderById(int id)
        {
            return Ok(_providerService.GetProviderById(id));
        }
    }
}