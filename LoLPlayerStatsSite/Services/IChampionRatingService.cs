using LoLPlayerStatsSite.Components.Pages.ChampionSelectPage.Model;
using LoLPlayerStatsSite.Db.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoLPlayerStatsSite.Service
{
    public interface IChampionRatingService
    {
        public Task<bool> CreateChampionRating(ChampionSelectFormModel newChampionRating);
        public Task<bool> DeleteChampionRating(ChampionRating championRating);
        public Task<List<ChampionRating>> GetAllChampionRatingsAsync();
        public Task<ChampionRating> GetSingleChampionRatingAsync(int championRatingId);
        public Task<bool> UpdateChampionRating(ChampionSelectFormModel championRatingToUpdate, ChampionRating existingRating);
        public Task SaveASync();

    }
}
