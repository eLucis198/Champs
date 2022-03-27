using System.Collections.Generic;
using System.Threading.Tasks;
using Champs.Application.DTOs;
using Champs.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Champs.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionController
    {
        private IChampionService _championService;

        public ChampionController(IChampionService championService)
        {
            _championService = championService;
        }

        [HttpGet]
        public async Task<IEnumerable<ChampionDTO>> GetChampions(){
            return await _championService.GetChampions();
        }
    }
}