using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PressBox.Domain.Models;
using PressBox.Services;

namespace PressBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private IBrandServices brandServices;

        public LeaguesController(IBrandServices brandServices)
        {
            this.brandServices = brandServices;
        }

        [HttpGet]
        public async Task<List<League>> Get()
        {
            return await brandServices.GetLeagues();
        }

        //
        [HttpGet("{id}/matches")]
        public async Task<List<Match>> BrandedTeams(int id)
        {
            return await brandServices.GetMatchesInLeague(id);
        }
    }
}