using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PressBox.Domain.Models;
using PressBox.Services;

namespace PressBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandingController : ControllerBase
    {
        private IBrandServices brandServices;

        public BrandingController(IBrandServices brandServices)
        {
            this.brandServices = brandServices;
        }

        [HttpGet]
        public async Task<List<Brand>> Get()
        {
            return await brandServices.GetBrands();
        }

        [HttpGet("{id}/teams/{idLeague}")]
        public async Task<List<BrandedMatch>> Matches(int id, int idLeague)
        {
            return await brandServices.GetBrandedMatchesInLeague(idLeague, id);
        }
    }
}
