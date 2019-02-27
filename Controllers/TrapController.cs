using System.Collections.Generic;
using TrapApi.Models;
using TrapApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TrapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrapController : ControllerBase
    {
        private readonly TrapService _trapService;

        public TrapController(TrapService trapService)
        {
            _trapService = trapService;
        }

        [HttpGet]
        public ActionResult<List<Trap>> Get()
        {
            return _trapService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTrap")]
        public ActionResult<Trap> Get(string id)
        {
            var trap = _trapService.Get(id);

            if (trap == null)
            {
                return NotFound();
            }

            return trap;
        }

        [HttpPost]
        public ActionResult<Trap> Create(Trap trap)
        {
            _trapService.Create(trap);

            return CreatedAtRoute("GetTrap", new { id = trap.Id.ToString() }, trap);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Trap trapIn)
        {
            var trap = _trapService.Get(id);

            if (trap == null)
            {
                return NotFound();
            }

            _trapService.Update(id, trapIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var trap = _trapService.Get(id);

            if (trap == null)
            {
                return NotFound();
            }

            _trapService.Remove(trap.Id);

            return NoContent();
        }
    }
}