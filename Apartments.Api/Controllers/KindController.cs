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
        public IActionResult GetKinds()
        {
            return Ok(_kindService.GetKinds());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetKindById(int id)
        {
            return Ok(_kindService.GetKindById(id));
        }
        
        [HttpPost]
        public IActionResult CreateKind(KindViewItem kindViewItem)
        {
            return Ok(_kindService.CreateKind(kindViewItem));
        }
        
        [HttpPut]
        public IActionResult UpdateKind(KindViewItem kindViewItem)
        {
            return Ok(_kindService.UpdateKind(kindViewItem));
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteKind(int id)
        {
            return Ok(_kindService.DeleteKind(id));
        }
    }
}