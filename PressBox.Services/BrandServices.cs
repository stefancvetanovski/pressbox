using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PressBox.Domain.Models;

namespace PressBox.Services
{
    public class BrandServices : IBrandServices
    {
        private readonly HttpClient httpClient;
        private IConfiguration config;
        private readonly string baseUrl;
        private readonly string sasToken;
        private readonly IMapper mapper;
        public BrandServices(HttpClient httpClient, 
            IConfiguration config, 
            IMapper mapper)
        {
            this.httpClient = httpClient;
            this.config = config;
            this.mapper = mapper;
            this.baseUrl = config["ApiBaseUrl"];
            this.sasToken = config["SasToken"];
        }

        public async Task<List<League>> GetLeagues()
        {
            var warehouseResponse = await httpClient.GetStringAsync($"{baseUrl}/leagues.json?{sasToken}");
            return JsonConvert.DeserializeObject<List<League>>(warehouseResponse);
        }

        public async Task<List<Brand>> GetBrands()
        {
            var warehouseResponse = await httpClient.GetStringAsync($"{baseUrl}/brands.json?{sasToken}");
            return JsonConvert.DeserializeObject<List<Brand>>(warehouseResponse);
        }

        public async Task<List<Match>> GetMatchesInLeague(int idLeague)
        {
            var warehouseResponse = await httpClient.GetStringAsync($"{baseUrl}/leagues/{idLeague}.json?{sasToken}");
            return JsonConvert.DeserializeObject<List<Match>>(warehouseResponse);
        }

        public async Task<List<BrandedMatch>> GetBrandedMatchesInLeague(int idLeague, int idBrand)
        {
            var matches = await GetMatchesInLeague(idLeague);
            return await GetBrandedMatches(matches, idBrand);
        }

        public async Task<List<BrandedMatch>> GetBrandedMatches(List<Match> matches, int idBrand)
        {
            var returnList = new List<BrandedMatch>();
            var warehouseBrandinfo = await httpClient.GetStringAsync($"{baseUrl}/brands/{idBrand}.json?{sasToken}");
            var brandInfo = JsonConvert.DeserializeObject<List<BrandEntity>>(warehouseBrandinfo);
            var brandLookup = new Dictionary<string, BrandEntity>();
            foreach (var brandEntity in brandInfo)
            {
                if(brandLookup.ContainsKey(brandEntity.TeamId))
                    continue;
                brandLookup.Add(brandEntity.TeamId, brandEntity);
            }

            foreach (var match in matches)
            {
                var brandedHomeTeam = mapper.Map<BrandedTeam>(match.HomeTeam);
                var brandedAwayTeam = mapper.Map<BrandedTeam>(match.AwayTeam);
                if (brandLookup.ContainsKey(brandedHomeTeam.Id))
                    brandedHomeTeam.Brand = brandLookup[brandedHomeTeam.Id];
                if (brandLookup.ContainsKey(brandedAwayTeam.Id))
                    brandedAwayTeam.Brand = brandLookup[brandedAwayTeam.Id];
                var brandedMatch = mapper.Map<BrandedMatch>(match);
                brandedMatch.AwayTeam = brandedAwayTeam;
                brandedMatch.HomeTeam = brandedHomeTeam;
                returnList.Add(brandedMatch);
            }
            return returnList;
        }
    }
}
