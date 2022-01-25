using Apartment.Business.Interfaces;
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
    }
}