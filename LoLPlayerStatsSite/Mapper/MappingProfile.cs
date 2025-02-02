using AutoMapper;
using LoLPlayerStatsSite.Components.Pages.ChampionSelectPage.Model;
using LoLPlayerStatsSite.Db.Models;

namespace LoLPlayerStatsSite.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChampionSelectFormModel, ChampionRating>();
        }
    }
}
