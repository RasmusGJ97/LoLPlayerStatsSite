using AutoMapper;
using LoLPlayerStatsSite.Db.AppDbContext;
using LoLPlayerStatsSite.RiotAPI;
using LoLPlayerStatsSite.RiotAPI.DTOs;
using LoLPlayerStatsSite.Service;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LoLPlayerStatsSite.Services
{
    public class PlayerStatsService : IPlayerStatsService
    {
        private readonly IRiotAPIProvider _riotAPIProvider;
        private readonly ILogger<PlayerStatsService> _log;
        private readonly IMapper _mapper;

        public PlayerStatsService(IRiotAPIProvider iRiotAPIProvider, ILogger<PlayerStatsService> logger, IMapper mapper)
        {
            _riotAPIProvider = iRiotAPIProvider;
            _log = logger;
            _mapper = mapper;
        }
        public async Task<RiotGetUserResponseDto> GetSingleUserIdWithGameNameAndTag(string gameName, string tag)
        {
            try
            {
                var user = await _riotAPIProvider.GetSingleUserByGameNameAndTag(gameName, tag);

                if (user is null)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, $"Message: {ex.Message}. Method: {MethodBase.GetCurrentMethod().Name ?? ""}.");
                throw new Exception("An error occurred while fetching champion ratings.", ex);
            }
        }
    }
}
