using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Application.DTOs;
using Champs.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Champs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionController : ControllerBase
    {
        private readonly IChampionService _championService;

        public ChampionController(IChampionService championService)
        {
            _championService = championService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChampionDTO>>> GetChampions()
        {
            var champions = await _championService.GetChampions();
            if (champions == null)
                return NotFound("Champions not found");

            return Ok(champions);
        }

        [HttpGet("{id:int}", Name = "GetChampion")]
        public async Task<ActionResult<ChampionDTO>> GetChampion(int id)
        {
            var champion = await _championService.GetById(id);
            if (champion == null)
                return NotFound("Champion not found");

            return Ok(champion);
        }

        [HttpPost]
        public async Task<ActionResult> PostChampion([FromBody] ChampionDTO championDto)
        {
            if (championDto == null || championDto.Stat == null)
                return BadRequest("Invalid data");

            await _championService.Create(championDto);

            return new CreatedAtRouteResult("GetChampion", new { id = championDto.Id }, championDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutChampion(int id, [FromBody] ChampionDTO championDto)
        {
            if (championDto == null || championDto.Stat == null)
                return BadRequest("Invalid data");

            if (id != championDto.Id)
                return BadRequest("Invalid data");

            var champion = await _championService.GetById(id);
            if (champion == null)
                return NotFound("Champion not found");

            if (champion.Stat.Id != championDto.Stat.Id)
                return BadRequest("Invalid data");

            await _championService.Update(championDto);

            return new CreatedAtRouteResult("GetChampion", new { id = championDto.Id }, championDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ChampionDTO>> DeleteChampion(int id)
        {
            var champion = await _championService.GetById(id);
            if (champion == null)
                return NotFound("Champion not found");

            await _championService.Delete(id);
            return Ok(champion);
        }
    }
}