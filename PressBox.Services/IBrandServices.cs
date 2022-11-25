using System.Collections.Generic;
using System.Threading.Tasks;
using PressBox.Domain.Models;

namespace PressBox.Services
{
    public interface IBrandServices
    {
        Task<List<League>> GetLeagues();
        Task<List<Brand>> GetBrands();
        Task<List<Match>> GetMatchesInLeague(int idLeague);
        Task<List<BrandedMatch>> GetBrandedMatchesInLeague(int idLeague, int idBrand);
        Task<List<BrandedMatch>> GetBrandedMatches(List<Match> matches, int idBrand);
    }
}
