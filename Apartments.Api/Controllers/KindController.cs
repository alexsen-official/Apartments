using System.Collections.Generic;
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
            IEnumerable<KindViewItem> result = _kindService.GetKinds();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetKindById(int id)
        {
            KindViewItem result = _kindService.GetKindById(id);
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult CreateKind(KindViewItem kindViewItem)
        {
            IEnumerable<KindViewItem> result = _kindService.CreateKind(kindViewItem);
            return Ok(result);
        }
        
        [HttpPut]
        public IActionResult UpdateKind(KindViewItem kindViewItem)
        {
            IEnumerable<KindViewItem> result = _kindService.UpdateKind(kindViewItem);
            return Ok(result);
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteKind(int id)
        {
            IEnumerable<KindViewItem> result = _kindService.DeleteKind(id);
            return Ok(result);
        }
    }
}