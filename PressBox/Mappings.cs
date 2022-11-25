using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PressBox.Domain.Models;

namespace PressBox
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Match, BrandedMatch>().ReverseMap();
            CreateMap<Team, BrandedTeam>().ReverseMap();
        }
    }
}
