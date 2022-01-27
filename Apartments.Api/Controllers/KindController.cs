using System.Threading.Tasks;
using Apartment.Business.Interfaces;
using Apartments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Apartments.Controllers
{
    [Route("/api/[controller]"), ApiController]
    public class KindController : Controller
    {
        private readonly IKindService _kindService;

        public KindController(IKindService kindService)
        {
            _kindService = kindService;
        }

        [HttpGet]
        public async Task<IActionResult> GetKinds()
        {
            var result = await _kindService.GetKinds();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetKindById(int id)
        {
            var result = await _kindService.GetKindById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateKind(KindViewItem kindViewItem)
        {
            var result = await _kindService.CreateKind(kindViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateKind(KindViewItem kindViewItem)
        {
            var result = await _kindService.UpdateKind(kindViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteKind(int id)
        {
            var result = await _kindService.DeleteKind(id);
            return Ok(result);
        }
    }
}