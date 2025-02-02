using AutoMapper;
using LoLPlayerStatsSite.Components.Pages.ChampionSelectPage.Model;
using LoLPlayerStatsSite.Db.AppDbContext;
using LoLPlayerStatsSite.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LoLPlayerStatsSite.Service
{
    public class ChampionRatingService : IChampionRatingService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ChampionRatingService> _log;
        private readonly IMapper _mapper;

        public ChampionRatingService(AppDbContext context, ILogger<ChampionRatingService> logger, IMapper mapper)
        {
            _context = context;
            _log = logger;
            _mapper = mapper;
        }

        public async Task<bool> CreateChampionRating(ChampionSelectFormModel newChampionRating)
        {
            try
            {
                ChampionRating newRating = new ChampionRating();
                _mapper.Map(newChampionRating, newRating);

                await _context.ChampionRatings.AddAsync(newRating);
                return true;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Message: {ex.Message}. Method: {MethodBase.GetCurrentMethod().Name ?? ""}.");
                throw new Exception("An error occurred while fetching champion ratings.", ex);
            }
        }

        public async Task<bool> DeleteChampionRating(ChampionRating championRating)
        {
            try
            {
                var result = _context.ChampionRatings.Remove(championRating);
                return true;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Message: {ex.Message}. Method: {MethodBase.GetCurrentMethod().Name ?? ""}.");
                throw new Exception("An error occurred while fetching champion ratings.", ex);
            }
        }

        public async Task<List<ChampionRating>> GetAllChampionRatingsAsync()
        {
            try
            {
                var result = await _context.ChampionRatings.ToListAsync();

                if (result is null || result.Count == 0)
                {
                    return new List<ChampionRating>();
                }
                return result;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Message: {ex.Message}. Method: {MethodBase.GetCurrentMethod().Name ?? ""}.");
                throw new Exception("An error occurred while fetching champion ratings.", ex);
            }
        }

        public async Task<ChampionRating> GetSingleChampionRatingAsync(int championRatingId)
        {
            try
            {
                var championRating = await _context.ChampionRatings.FirstOrDefaultAsync(c => c.Id == championRatingId);

                if (championRating is null)
                {
                    return null;
                }
                return championRating;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Message: {ex.Message}. Method: {MethodBase.GetCurrentMethod().Name ?? ""}.");
                throw new Exception("An error occurred while fetching champion ratings.", ex);
            }
        }

        public async Task<bool> UpdateChampionRating(ChampionSelectFormModel championRatingToUpdate, ChampionRating existingRating)
        {
            try
            {
                if (existingRating != null)
                {
                    _mapper.Map(championRatingToUpdate, existingRating);

                    _context.ChampionRatings.Update(existingRating);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Message: {ex.Message}. Method: {MethodBase.GetCurrentMethod().Name ?? ""}.");
                throw new Exception("An error occurred while fetching champion ratings.", ex);
            }
        }

        public async Task SaveASync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
