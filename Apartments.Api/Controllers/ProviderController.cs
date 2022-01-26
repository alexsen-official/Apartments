using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
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
        
        [HttpPost]
        public IActionResult CreateProvider(ProviderViewItem providerViewItem)
        {
            return Ok(_providerService.CreateProvider(providerViewItem));
        }
        
        [HttpPut]
        public IActionResult UpdateProvider(ProviderViewItem providerViewItem)
        {
            return Ok(_providerService.UpdateProvider(providerViewItem));
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProvider(int id)
        {
            return Ok(_providerService.DeleteProvider(id));
        }
    }
}