using LoLPlayerStatsSite.RiotAPI.DTOs;

namespace LoLPlayerStatsSite.Services
{
    public interface IPlayerStatsService
    {
        Task<RiotGetUserResponseDto> GetSingleUserIdWithGameNameAndTag(string gameName, string tag);
    }
}
