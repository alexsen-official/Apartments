using System.Collections.Generic;
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
            IEnumerable<ProviderViewItem> result = _providerService.GetProviders();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProviderById(int id)
        {
            ProviderViewItem result = _providerService.GetProviderById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateProvider(ProviderViewItem providerViewItem)
        {
            IEnumerable<ProviderViewItem> result = _providerService.CreateProvider(providerViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult UpdateProvider(ProviderViewItem providerViewItem)
        {
            IEnumerable<ProviderViewItem> result = _providerService.UpdateProvider(providerViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProvider(int id)
        {
            IEnumerable<ProviderViewItem> result = _providerService.DeleteProvider(id);
            return Ok(result);
        }
    }
}