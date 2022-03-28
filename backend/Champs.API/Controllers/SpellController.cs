using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Application.DTOs;
using Champs.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Champs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpellController : ControllerBase
    {
        private readonly ISpellService _spellService;

        public SpellController(ISpellService spellService)
        {
            _spellService = spellService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChampionDTO>>> GetSpells()
        {
            var spells = await _spellService.GetSpells();

            if (spells == null)
                return NotFound("Champions not found");

            return Ok(spells);
        }

        [HttpGet("{id:int}", Name = "GetSpell")]
        public async Task<ActionResult<ChampionDTO>> GetSpell(int id)
        {
            var spell = await _spellService.GetById(id);

            if (spell == null)
                return NotFound("Spell not found");

            return Ok(spell);
        }

        [HttpPost]
        public async Task<ActionResult> PostSpell([FromBody] SpellDTO spellDto)
        {
            if (spellDto == null)
                return BadRequest("Invalid data");

            await _spellService.Create(spellDto);

            return new CreatedAtRouteResult("GetSpell", new { id = spellDto}, spellDto);
        }
    }
}