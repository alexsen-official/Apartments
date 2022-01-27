using System.Threading.Tasks;
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
        public async Task<IActionResult> GetProviders()
        {
            var result = await _providerService.GetProviders();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProviderById(int id)
        {
            var result = await _providerService.GetProviderById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProvider(ProviderViewItem providerViewItem)
        {
            var result = await _providerService.CreateProvider(providerViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProvider(ProviderViewItem providerViewItem)
        {
            var result = await _providerService.UpdateProvider(providerViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            var result = await _providerService.DeleteProvider(id);
            return Ok(result);
        }
    }
}